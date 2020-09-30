using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant_Ratings_Final_Proj.Models;

[assembly: HostingStartup(typeof(Restaurant_Ratings_Final_Proj.Areas.Identity.IdentityHostingStartup))]
namespace Restaurant_Ratings_Final_Proj.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Restaurant_Ratings_IdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Restaurant_Ratings_IdentityContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<Restaurant_Ratings_IdentityContext>();
            });
        }
    }
}