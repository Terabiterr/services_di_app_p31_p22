using Microsoft.EntityFrameworkCore;
using services_di_app.Data;
using services_di_app.Services;

namespace services_di_app
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);  
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); // Use SQL Server with the default connection string  
            });

            builder.Services.AddScoped<ICRUDService, UserService>();
            builder.Services.AddControllers();

            var app = builder.Build();

            app.UseStaticFiles();
            app.MapControllers();

            app.Run();
        }
    }
}
