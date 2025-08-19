using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Models;
using RestaurantManagement.Models.Dtos;
using RestaurantManagement.Reposetories.IReposetory;
using RestaurantManagement.Servisies;


namespace RestaurantManagement.Reposetories.Reposetory
{
    public class CategoryReposetory : Repository<Category>, ICategoryReposetory
    {
        private readonly IEmailService _emailService;
        private readonly IMailkitEmeilService _mailkitEmeilService;
        private readonly IEmailTempletService _emailTempletService;
        private readonly ApplicationDbcontext _context;
        private readonly IPdfExportService _exportService;
        public CategoryReposetory(ApplicationDbcontext applicationDb,
            IEmailService emailService, IEmailTempletService emailTempletService, IMailkitEmeilService mailkitEmeilService, IPdfExportService exportService) : base(applicationDb)
        {
            _context = applicationDb;
            _emailService = emailService;
            _emailTempletService = emailTempletService;
            _mailkitEmeilService = mailkitEmeilService;
            _exportService = exportService;
        }
        public async Task<CategoryOutputDto> CreateCategoryAsync(CreateEmailWithMilkitDto dto,CancellationToken ct = default)
        {

            var dishes = await _context.Dishes
                .Where(d => dto.dishids.Contains(d.Id))
                .ToListAsync();

            if (dishes.Count != dto.dishids.Count)
                throw new Exception("Some dishes not found");

            var category = new Category
            {
                Name = dto.Name,
                Description = dto.Description,
                dishes = dishes
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == dto.UserId);
            if (user != null)
            {
                var placeholders = new Dictionary<string, string>
             {
                  { "{{Name}}", user.Name },
                  { "{{CategoryName}}", category.Name }
              };

                //الكود بتاع استدعاء ال تمبليت بتاعت ارسال الايميل 
                 var emailBody = await _emailTempletService.GetEmailBodyAsync("Templates.html", placeholders);
                // await _emailService.SendEmailAsync(user.Email, "Category Created", emailBody);
                await _mailkitEmeilService.SendEmailWithMailkitAsync(user.Email, "Category Created", emailBody, ct);
            }
            ;
           
            return new CategoryOutputDto
            {
                Name = category.Name,
                Description = category.Description,
                DishIds = category.dishes.Select(d => d.Id).ToList()
            };
        }

       

    }

}     
    

