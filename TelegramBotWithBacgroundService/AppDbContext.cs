using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TelegramBotWithBacgroundService
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        Database.Migrate();
        }

        public DbSet<UserModel> Users { get; set; }
    }
}
