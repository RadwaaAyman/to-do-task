using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Enums;

namespace ToDo.Application.DTOS;

/// <summary>
/// Data Transfer Object (DTO) used for creating or updating an todo.
/// </summary>
public class CreateUpdateToDoDto
{
    /// <summary>
    /// Gets or sets the todo's title.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the todo's description.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the status of the employee.
    /// </summary>
    public Status Status { get; set; }

    /// <summary>
    /// Gets or sets the priority of the todo.
    /// </summary>
    public Priority Priority { get; set; }

    /// <summary>
    /// Gets or sets the dueDate of the todo.
    /// </summary>
    public DateTime DueDate { get; set; } 
}
