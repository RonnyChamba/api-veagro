using InventarioVeagroApi.Messages.Response;
using InventarioVeagroApi.Models;

namespace InventarioVeagroApi.Util
{
    public class TemplateUtil
    {


        public static string TemplateSaleReportGeneral = @"

<!DOCTYPE html>
<html lang='es'>

<head>
    <meta charset='UTF-8'>
    <title>Reporte de Ventas</title>
    <style>
        body {
            font-family: Arial, sans-serif;
        }

        .header {
            width: 100%;
            margin-bottom: 20px;
        }

        .logo {
            width: 100px;
            height: auto;
            vertical-align: middle;
        }

        .company-info {
            display: inline-block;
            vertical-align: middle;
            margin-left: 10px;
        }

        .company-info h2 {
            margin: 0;
            font-size: 18px;
        }

        .company-info p {
            margin: 2px 0;
            font-size: 14px;
        }

        h1 {
            text-align: center;
        }

        table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        th,
        td {
            border: 1px solid black;
            padding: 8px;
            text-align: left;
        }

        th {
            background-color: #f2f2f2;
        }

        .total-section {
            margin-top: 20px;
            text-align: right;
            font-size: 16px;
            font-weight: bold;
        }
    </style>
</head>

<body>

    
    <div class=""header"">
        <img src=""https://olimpush.com/assets/olimpush.png"" alt=""Logo Empresa"" class=""logo"">
        <div class=""company-info"">
            <h2>[KEY_COMPANY_NAME]</h2>
            <p>Dirección: [KEY_COMPANY_ADDRESS]</p>
            <p>Teléfono: [KEY_COMPANY_TLF]</p>
        </div>
    </div>

    
    <h1>Reporte de Ventas - [KEY_FILTER_DATE]</h1>

    
    <table>
        <thead>
            <tr>
                <th>#</th>
                <th>Cliente</th>
                <th>Tlf</th>
                <th>Correo</th>
                <th>Fecha</th>
                <th>Total</th>
            </tr>
        </thead>
        <tbody>
           [KEY_ROWS_SALES]
        </tbody>
    </table>
    <div class=""total-section"">
        Total de Ventas: <span>[KEY_SUM_TOTALS]</span>
    </div>

</body>

</html>
";


        public static string TemplateSaleReport = @"
           
         <!DOCTYPE html>
<html lang='es'>

<head>
    <meta charset='UTF-8'>
    <title>Factura</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 20px;
        }

        .header {
            width: 100%;
            margin-bottom: 20px;
        }

        .logo {
            width: 100px;
            height: auto;
            vertical-align: middle;
        }

        .company-info {
            display: inline-block;
            vertical-align: middle;
            margin-left: 10px;
        }

        .company-info h2 {
            margin: 0;
            font-size: 18px;
        }

        .company-info p {
            margin: 2px 0;
            font-size: 14px;
        }

        h1 {
            text-align: center;
        }

        .factura-info, .cliente-info {
            width: 100%;
            margin-bottom: 20px;
        }

        .factura-info td, .cliente-info td {
            padding: 5px;
            border: 1px solid black;
        }

        table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 10px;
        }

        th, td {
            border: 1px solid black;
            padding: 8px;
            text-align: left;
        }

        th {
            background-color: #f2f2f2;
        }

        .total-section {
            margin-top: 20px;
            text-align: right;
            font-size: 16px;
            font-weight: bold;
        }
    </style>
</head>

<body>

    <div class=""header"">
        <img src=""https://olimpush.com/assets/olimpush.png"" alt=""Logo Empresa"" class=""logo"">
        <div class=""company-info"">
            <h2>[KEY_COMPANY_NAME]</h2>
            <p>Dirección: [KEY_COMPANY_ADDRESS]</p>
            <p>Teléfono: [KEY_COMPANY_TLF]</p>
        </div>
    </div>

    <table class=""factura-info"">
        <tr>
            <td><strong>Factura No.:</strong> [KEY_INVOICE_NUMBER]</td>
            <td><strong>Fecha:</strong> [KEY_DATE_CREATE]</td>
        </tr>
    </table>
    
    <table class=""cliente-info"">
        <tr>
            <td><strong>Cliente:</strong> [KEY_FULLNAME_CUSTOMER]</td>
            <td><strong>Teléfono:</strong> [KEY_TLF_CUSTOMER]</td>
        </tr>
        <tr>
            <td><strong>Correo:</strong> [KEY_EMAIL_CUSTOMER]</td>
            <td><strong>Dirección:</strong> [KEY_ADDRESS_CUSTOMER]</td>
        </tr>
    </table>
    <table>
        <thead>
            <tr>
                <th>#</th>
                <th>Codigo</th>
                <th>Cantidad</th>
                <th>Descripción</th>
                <th>Precio Unitario</th>
                <th>Subtotal</th>
            </tr>
        </thead>
        <tbody>
            [KEY_ROWS_DETAILS]
        </tbody>
    </table>
    <div class=""total-section"">
        <p><strong>Total:</strong> [KEY_TOTAL_SALE]</p>
    </div>

</body>

</html>

    
        ";


        public static string ReemplazarPlaceholders(string htmlTemplate, Dictionary<string, string> valores)
        {
            foreach (var kvp in valores)
            {
                htmlTemplate = htmlTemplate.Replace(kvp.Key, kvp.Value);
            }
            return htmlTemplate;
        }

        public static string GenerarTablaVentas(List<SaleResDTO> sales)
        {
            string tablaHtml = "";
            int index = 1;
            foreach (var sale in sales)
            {
                tablaHtml += $"<tr><td>{index}</td><td>{sale.Name}</td> <td>{sale.Cellphone}</td> <td>{sale.Email}</td><td>{sale.CreateDate}</td> <td>${sale.Total:F2}</td></tr>";

                index++;
            }
            return tablaHtml;
        }

        public static string GenerarRowsDetailsSale(List<SaleDetail> saleDetails)
        {
            string tablaHtml = "";
            int index = 1;
            foreach (var sale in saleDetails)
            {

                tablaHtml += $"""
                    <tr>
                        <td>{index}</td>
                        <td>{sale.MainCode}</td>
                        <td>{sale.Amount}</td>
                        <td>{sale.Description}</td>
                        <td>{sale.Price}</td>
                        <td>${sale.Subtotal:F2}</td>
                    </tr>
                    """;
                index++;
            }
            return tablaHtml;
        }

    }
}
