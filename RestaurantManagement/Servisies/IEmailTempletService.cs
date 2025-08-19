namespace RestaurantManagement.Servisies
{
    public interface IEmailTempletService
    {
        Task<string> GetEmailBodyAsync(string templatePath, Dictionary<string, string> placeholders);
    }
}