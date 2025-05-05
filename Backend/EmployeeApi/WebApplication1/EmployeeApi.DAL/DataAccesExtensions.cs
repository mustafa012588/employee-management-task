using EmployeeApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeApi.DAL;

public static class DataAccesExtensions
{
    public static void AddDataAccesServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<EmployeeContext>(options =>
            options
                .UseSqlServer(connectionString));
        

        services.AddScoped<IEmployeeRepo, EmployeeRepo>();

    }
}
