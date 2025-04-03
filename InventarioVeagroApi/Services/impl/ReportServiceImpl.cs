using InventarioVeagroApi.Exceptions;
using InventarioVeagroApi.Messages.Request;
using InventarioVeagroApi.Messages.Response;
using InventarioVeagroApi.Models;
using InventarioVeagroApi.Util;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;

namespace InventarioVeagroApi.Services.impl
{
    public class ReportServiceImpl : IReportService
    {

        private readonly ILogger<ReportServiceImpl> _logger;
        private readonly ProductContext _productContext;
        private readonly IMapperService _mapperService;
        private readonly IPdfService _pdfService;

        public ReportServiceImpl(ILogger<ReportServiceImpl> logger, ProductContext productContext, IMapperService mapperService, IPdfService pdfService)
        {
            _logger = logger;
            _productContext = productContext;
            _mapperService = mapperService;
            _pdfService = pdfService;
        }

        public async Task<GenericRespDTO<string>> GenerateReport(GenericReqDTO<ReportReqDTO> genericReqDTO)
        {

            _logger.LogInformation("Reporte: {}", genericReqDTO);

            ReportReqDTO data = genericReqDTO.payload;
            List<Sale> sales =  await GetSaleByFilters(data);

            List<SaleResDTO> salesResp = sales.Select(sale => _mapperService.SaleResDTO(sale)).ToList();
            string rowTableTbody = TemplateUtil.GenerarTablaVentas(salesResp);
            decimal sumTotalSales = SumTotalSales(salesResp);

            Dictionary<string, string> keyValuePairs = CreateValuePairsTemplate(rowTableTbody, sumTotalSales, data);

            string templateReplaced = TemplateUtil.ReemplazarPlaceholders(TemplateUtil.TemplateSaleReportGeneral, keyValuePairs);

            _logger.LogInformation("{}", templateReplaced);

            string pdfPath = await _pdfService.ConvertHtmlToPdf(templateReplaced, "");

            _logger.LogInformation("pdfPath: {}", pdfPath);

            return GeneralUtil.CreateSuccessResp(pdfPath, "Pf");
        }

        public async Task<List<Sale>> GetSaleByFilters(ReportReqDTO data) {

            string[] formats = { "yyyy-MM-dd", "dd/MM/yyyy", "MM/dd/yyyy" };
            
            DateOnly dateStart = DateOnly.ParseExact(data.DateStart, formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
            DateOnly dateEnd = DateOnly.ParseExact(data.DateEnd, formats, CultureInfo.InvariantCulture, DateTimeStyles.None);

            return await _productContext
                                    .Sale
                                      .Where(s => DateOnly.FromDateTime(s.CreateDate) >= dateStart &&
                                                    DateOnly.FromDateTime(s.CreateDate) <= dateEnd)
                                       .ToListAsync();


        }

        public Dictionary<string, string> CreateValuePairsTemplate(string rowTableTbody,
            decimal sumTotales,
            ReportReqDTO reportReqDTO
            )
        {
            Dictionary<string, string> mapValues = new Dictionary<string, string>();
            mapValues.Add("[KEY_COMPANY_NAME]",  ConstantVeagro.COMPANY_NAME);
            mapValues.Add("[KEY_COMPANY_ADDRESS]", ConstantVeagro.COMPANY_ADDRESS);
            mapValues.Add("[KEY_COMPANY_TLF]", "092325634O");
            mapValues.Add("[KEY_ROWS_SALES]", rowTableTbody);
            mapValues.Add("[KEY_SUM_TOTALS]", sumTotales.ToString());
            mapValues.Add("[KEY_FILTER_DATE]", $"{reportReqDTO.DateStart} - {reportReqDTO.DateEnd}");

            return mapValues;
        }

        public decimal SumTotalSales(List<SaleResDTO> salesResp)
        {

            return salesResp.Sum(sale => sale.Total);
        }

        public async Task<GenericRespDTO<string>> GenerateReportSale(int saleId)
        {

            _logger.LogInformation("Reporte factura # : {}", saleId);
            Sale sale = await _productContext
                .Sale
                .Where(sale => sale.Id == saleId)
                .Include(sale => sale.Details)
                .FirstOrDefaultAsync() ?? throw new NotFoundException($"No se encontro la factura con id {saleId}");


            Dictionary<string, string> keyValueToReplace = GenerateKeysSalePdf (sale);

            string templateReplaced = TemplateUtil.ReemplazarPlaceholders(TemplateUtil.TemplateSaleReport, keyValueToReplace);

            string pdfPath = await _pdfService.ConvertHtmlToPdf(templateReplaced, "");

            return GeneralUtil.CreateSuccessResp(pdfPath, "");
        }

        private Dictionary<string, string> GenerateKeysSalePdf(Sale sale)
        {

            Dictionary<string, string> mapValues = new Dictionary<string, string>();
            mapValues.Add("[KEY_COMPANY_NAME]", ConstantVeagro.COMPANY_NAME);
            mapValues.Add("[KEY_COMPANY_ADDRESS]", ConstantVeagro.COMPANY_ADDRESS);
            mapValues.Add("[KEY_COMPANY_TLF]", "092325634O");
            mapValues.Add("[KEY_INVOICE_NUMBER]", $"{sale.Id}");
            mapValues.Add("[KEY_DATE_CREATE]", $"{sale.CreateDate}");
            mapValues.Add("[KEY_FULLNAME_CUSTOMER]", sale.Name);
            mapValues.Add("[KEY_TLF_CUSTOMER]", sale.Cellphone?? "NA");
            mapValues.Add("[KEY_EMAIL_CUSTOMER]", sale.Email?? "NA");
            mapValues.Add("[KEY_ADDRESS_CUSTOMER]", sale.Address?? "NA");
            mapValues.Add("[KEY_ROWS_DETAILS]", TemplateUtil.GenerarRowsDetailsSale(sale.Details));
            mapValues.Add("[KEY_TOTAL_SALE]", sale.Total.ToString());
          

            return mapValues;
        }
    }

}
