using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Entities;
using ToDo.Domain.Enums;

namespace ToDo.Domain.Entities;

/// <summary>
/// Represents an todo entity.
/// </summary>
public class ToDoEntity : AuditableEntity
{
    /// <summary>
    /// Gets or sets the title of the todo.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the description of the todo.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the status of the todo.
    /// </summary>
    public Status Status { get; set; }

    /// <summary>
    /// Gets or sets the priority of the todo.
    /// </summary>
    public Priority Priority { get; set; }

    /// <summary>
    /// Gets or sets the dueDate of the todo.
    /// </summary>
    public DateTime DueDate { get; set; } = DateTime.Now;
}
