using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Models;
using RestaurantManagement.Reposetories.IReposetory;
using RestaurantManagement.Reposetories.Reposetory;
using RestaurantManagement.Servisies;
using RestaurantManagement.validation;
using System.Reflection;


namespace RestaurantManagement
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // ده عشان اعرف ملف ال validation بتاعي عشان يشتغل مع ال fluent validation
            builder.Services.AddControllers().AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbcontext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.Configure<EmailSettings>(
                 builder.Configuration.GetSection("EmailSettings"));
            builder.Services.AddSingleton<RazorLight.RazorLightEngine>(sp =>
                      new RazorLight.RazorLightEngineBuilder()
                     .UseEmbeddedResourcesProject(typeof(Program))
                     .UseMemoryCachingProvider()
                     .Build());
            builder.Services.AddScoped<IPdfExportService, PdfExportService>();
            builder.Services.AddScoped<IMailkitEmeilService, MailkitEmeilService>();
            builder.Services.AddSingleton<IEmailTempletService, EmailTempletService>();
            builder.Services.AddScoped<IEmailService, EmailService>();
            builder.Services.AddScoped<IReservationReposetory, ReservationReposetory>();
            builder.Services.AddScoped<IOrderReposetory, OrderReposetory>();
            builder.Services.AddScoped<IOrderItemReposetory, OrderItemReposetory>();
            builder.Services.AddScoped<ICustomerReposetory, CustomerReposetory>();
            builder.Services.AddScoped<ICategoryReposetory, CategoryReposetory>();
            builder.Services.AddScoped<IDishReposetory, DishReposetory>();
            builder.Services.AddScoped<IInventoryReposetory, InventoryReposetory>();
          
            var app = builder.Build();




            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
