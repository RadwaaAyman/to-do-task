using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Contracts;
using ToDo.Application.Services;
using ToDo.Application.Validations;

namespace ToDo.Application.ExtensionForServices;

/// <summary>
/// Provides extension methods for the IServiceCollection interface.
/// </summary>
public static class ToDoServices
{
    /// <summary>
    /// Adds HrModule services to the specified IServiceCollection.
    /// </summary>
    /// <param name="services">The IServiceCollection to add services to.</param>
    /// <returns>The IServiceCollection with toDo services added.</returns>
    public static IServiceCollection AddToDoServices(this IServiceCollection services)
    {
        // TODO: Implement the logic to add HrModule services to the IServiceCollection

        services.AddValidatorsFromAssemblyContaining<CreateUpdateToDoDtoValidator>();
        services.AddScoped<IToDoService, ToDoService>();
        return services;
    }
}
