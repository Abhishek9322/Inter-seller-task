using Inter_seller_task.Models.Common;
using Inter_seller_task.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Inter_seller_task.Data.Seed
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context, PasswordHasher<User> passwordHasher)
        {
            await context.Database.MigrateAsync();

            var adminExists = await context.Users.AnyAsync(x => x.Role == Role.Admin); 
            if (adminExists) 
            {
                return;
            }
            var admin = new User { 
                Name = "System Admin",
                Email = "admin@interviewtask.com",
                MobileNo = "9999999999", 
                Country = "India",
                State = "Maharashtra",
                Role = Role.Admin,
                CreatedAt = DateTime.UtcNow 
            };

            admin.PasswordHash = passwordHasher.HashPassword(admin, "Admin@123");
            await context.Users.AddAsync(admin);

            await context.SaveChangesAsync();
        }
    }
}
