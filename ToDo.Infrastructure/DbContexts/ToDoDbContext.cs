using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Infrastructure.DbContexts;

/// <summary>
/// Represents the database context for the ToDo.
/// </summary>
public class ToDoDbContext : DbContext
{
    public DbSet<ToDoEntity> ToDos { get; set; }


    /// <summary>
    /// Initializes a new instance of the ToDoDbContext class.
    /// </summary>
    /// <param name="options">The DbContextOptions to use.</param>
    public ToDoDbContext(DbContextOptions options) : base(options)
    {
    }

    /// <summary>
    /// Configures the model by applying configurations from the current assembly.
    /// </summary>
    /// <param name="builder">The ModelBuilder to use.</param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Apply configurations from the current assembly
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Call the base method to perform any additional configuration
        base.OnModelCreating(builder);
    }
}
