
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NotificationService.Abstractions;
using NotificationService.Contracts.RequestModels;
using NotificationService.Data;
using NotificationService.Implementations;

namespace NotificationService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<INotificationSender, NotificationSender>();
            builder.Services.AddScoped<INotificationManageService, NotificationManageService>();
            builder.Services.AddValidatorsFromAssemblyContaining<NotificationSendRequestModelValidator>();
            builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Test"));
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
