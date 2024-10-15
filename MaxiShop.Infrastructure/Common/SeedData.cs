using MaxiShop.Domain.Models;
using MaxiShop.Infrastructure.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MaxiShop.Infrastructure.Common
{
    public class SeedData
    {


        public static async Task SeedRoles(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var roles = new List<IdentityRole>()
            {
                new IdentityRole { Name="ADMIN",NormalizedName="ADMIN"},
                new IdentityRole { Name="COSTOMER",NormalizedName="CUSTOMER"},
            };

            foreach (var role in roles)
            {
                if(!await roleManager.RoleExistsAsync(role.Name)) 
                {
                await roleManager.CreateAsync(role);
                }
            }
        }
        public static async Task SeedDataAsync(ApplicationDBContext _dbContext)
        {
            if (!_dbContext.Brand.Any())
            {
                return;
            }
            await _dbContext.AddRangeAsync(

                 new Brand
                 {
                     Name = "Apple",
                     EstablishedYear = 1964
                 },
                 new Brand
                 {
                     Name = "Sony",
                     EstablishedYear = 1964
                 },
                 new Brand
                 {
                     Name = "Samsung",
                     EstablishedYear = 1964
                 },
                 new Brand
                 {
                     Name = "Hp",
                     EstablishedYear = 1964
                 },
                 new Brand
                 {
                     Name = "Lenovo",
                     EstablishedYear = 1964
                 },
                 new Brand
                 {
                     Name = "Acer",
                     EstablishedYear = 1964
                 });
            await _dbContext.SaveChangesAsync();
        }




    }
    
}
