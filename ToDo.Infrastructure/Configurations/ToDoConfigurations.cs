using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Infrastructure.Configurations;

/// <summary>
/// Configuration for the ToDo entity.
/// </summary>
public class ToDoConfigurations : IEntityTypeConfiguration<ToDoEntity>
{
    /// <summary>
    /// Configures the ToDo entity.
    /// </summary>
    /// <param name="builder">The EntityTypeBuilder for the Employee entity.</param>
    public void Configure(EntityTypeBuilder<ToDoEntity> builder)
    {
        builder.Property(td => td.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(td => td.Description)
            .IsRequired(false)
            .HasMaxLength(150);

        builder.Property(td => td.DueDate)
            .IsRequired(false);
            
    }
}
