using RestaurantManagement.Models.Dtos;

namespace RestaurantManagement.Servisies
{
    public interface IMailkitEmeilService
    {
        Task SendEmailWithMailkitAsync(string toEmail, string subject, string htmlBody, CancellationToken ct = default);

    }
}
