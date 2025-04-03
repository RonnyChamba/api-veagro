using PuppeteerSharp;
using PuppeteerSharp.Media;

namespace InventarioVeagroApi.Services.impl
{
    public class PdfServiceImpl : IPdfService
    {
        private readonly ILogger<PdfServiceImpl> _logger;

        public PdfServiceImpl(ILogger<PdfServiceImpl> logger)
        { 
            _logger = logger;
        }
        public async  Task<string> ConvertHtmlToPdf(string htmlContent, string path)
        {

            _logger.LogInformation("Convirtiendo html a pdf");

            // Descargar Chromium si no está disponible
            await new BrowserFetcher().DownloadAsync();

            // Ruta donde se guardará el PDF
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), $"reporte_ventas_{DateTime.UtcNow.Ticks}.pdf");

            // Generar el PDF
            using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true,
                Args = new[] { "--no-sandbox", "--disable-setuid-sandbox" }
            });
            //using var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true });
            using var page = await browser.NewPageAsync();
            await page.SetContentAsync(htmlContent);
            await page.PdfAsync(filePath, new PdfOptions { Format = PaperFormat.A4 });

          return filePath;
        }
    }
}
