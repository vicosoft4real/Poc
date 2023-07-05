using System.Reflection;
using Application.Teachers.Create;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(c=> c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssemblyContaining<TeacherCreateRequestValidator>();
        
        
        
        return services;
    }
}