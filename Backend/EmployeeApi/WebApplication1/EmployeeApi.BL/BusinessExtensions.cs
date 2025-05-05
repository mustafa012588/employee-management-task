using EmployeeApi.BL;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeApi.BL;

public static class BusinessExtensions
{
    public static void AddBusinessServices(
        this IServiceCollection services)
    {
        services.AddScoped<IEmployeeService, EmployeeService>();
    }
}
