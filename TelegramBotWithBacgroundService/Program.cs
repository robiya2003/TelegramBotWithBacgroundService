
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Telegram.Bot.Polling;
using Telegram.Bot;
using TelegramBotWithBacgroundService.RegistratsiyaUserService;

namespace TelegramBotWithBacgroundService
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
            
            builder.Services.AddHostedService<Message>();
            builder.Services.AddHostedService<SendAllClientMessage>();

            //Singleton
            builder.Services.AddSingleton<IUpdateHandler, BotUpdateHandler>();

            builder.Services.AddSingleton(p =>
                new TelegramBotClient("6406750559:AAFoJbQbMTSYAzMQzcAphTNA5F7Kf7CG-GY"));

            // Service
            builder.Services.AddScoped<IUserService, UserService>();

            //Backend
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql("Host=localhost;Port=5432;Database=BotDb;User Id=postgres;Password=coder;");
            });
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
