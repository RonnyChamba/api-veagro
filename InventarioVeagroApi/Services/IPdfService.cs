namespace InventarioVeagroApi.Services
{
    public interface IPdfService
    {

        Task<string> ConvertHtmlToPdf(string htmlContent, string path);
    }
}
