using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.DTOS;
using ToDo.Core.Result;

namespace ToDo.Application.Contracts;

/// <summary>
/// Defines the interface for the ToDO Application Service.
/// </summary>
public interface IToDoService 
{
    /// <summary>
    /// Retrieves an todo by their unique identifier.
    /// </summary>
    /// <param name="id">The todo's unique identifier.</param>
    /// <returns>A result containing the todo's data transfer object.</returns>
    Task<Result<ToDoDto>> GetAsync(Guid id);

    /// <summary>
    /// Retrieves a list of all todos.
    /// </summary>
    /// <returns>A result containing a list of todo data transfer objects.</returns>
    Task<Result<List<ToDoDto>>> GetListAsync();
    /// <summary>
    /// Creates a new todo.
    /// </summary>
    /// <param name="createUpdateToDoDto">The data transfer object containing the todo's details.</param>
    /// <returns>A result indicating the outcome of the creation operation.</returns>
    Task<Result<ToDoDto>> CreateAsync(CreateUpdateToDoDto createUpdateToDoDto);

    /// <summary>
    /// Updates an existing todo.
    /// </summary>
    /// <param name="id">The todo's unique identifier.</param>
    /// <param name="createUpdateToDoDto">The data transfer object containing the updated todo details.</param>
    /// <returns>A result indicating the outcome of the update operation.</returns>
    Task<Result<string>> UpdateAsync(Guid id, CreateUpdateToDoDto createUpdateToDoDto);

    /// <summary>
    /// Deletes an todo by their unique identifier.
    /// </summary>
    /// <param name="id">The todo's unique identifier.</param>
    /// <returns>A result indicating the outcome of the deletion operation.</returns>
    Task<Result<string>> DeleteAsync(Guid id);
}
