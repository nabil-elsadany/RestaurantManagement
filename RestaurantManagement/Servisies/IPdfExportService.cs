namespace RestaurantManagement.Servisies
{
    public interface IPdfExportService
    {
        Task<byte[]> ExportTableToPdfAsync<T>(IEnumerable<T> data, string title);
    }
}
