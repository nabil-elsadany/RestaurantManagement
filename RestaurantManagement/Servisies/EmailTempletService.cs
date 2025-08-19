namespace RestaurantManagement.Servisies
{
    public class EmailTempletService : IEmailTempletService
    {
        public async Task<string> GetEmailBodyAsync(string templatePath, Dictionary<string, string> placeholders)
        {
            string body = await File.ReadAllTextAsync(templatePath);

            foreach (var placeholder in placeholders)
            {
                body = body.Replace(placeholder.Key, placeholder.Value);
            }

            return body;
        }
    }
}
