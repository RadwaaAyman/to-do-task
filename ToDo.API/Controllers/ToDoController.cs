using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Contracts;
using ToDo.Application.DTOS;
using ToDo.Core.Result;

namespace ToDo.API.Controllers;

[Route("api/[controller]")]
[ApiController]

/// <summary>
/// ToDoController is responsible for handling HTTP requests related to todo management.
/// </summary>
public class ToDoController : ControllerBase
{
    private readonly IToDoService _toDoService;

    /// <summary>
    /// Initializes a new instance of the ToDoController class.
    /// </summary>
    /// <param name="todoAppService">Instance of IToDoService.</param>
    /// 
    public ToDoController(IToDoService toDoService)
    {
        _toDoService = toDoService;
    }

    /// <summary>
    /// Retrieves an todo by their unique identifier.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<Result<ToDoDto>> GetToDoById(Guid id)
    {
        var result = await _toDoService.GetAsync(id);

        return result;
    }

    /// <summary>
    /// Retrieves a list of all todos.
    /// </summary>
    [HttpGet]
    public async Task<Result<List<ToDoDto>>> GetAllToDos()
    {
        var result = await _toDoService.GetListAsync();


        return result;
    }

    /// <summary>
    /// Creates a new todo.
    /// </summary>
    [HttpPost]
    public async Task<Result<ToDoDto>> CreateToDo([FromBody] CreateUpdateToDoDto createUpdateToDoDto)
    {
        var result = await _toDoService.CreateAsync(createUpdateToDoDto);
        
        return result;
    }

    /// <summary>
    /// Updates an existing todo.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<Result<string>> UpdateToDo(Guid id, [FromBody] CreateUpdateToDoDto createUpdateToDoDto)
    {
        var result = await _toDoService.UpdateAsync(id, createUpdateToDoDto);


        return result;
    }

    /// <summary>
    /// Deletes an todo by their unique identifier.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<Result<string>> DeleteToDo(Guid id)
    {
        var result = await _toDoService.DeleteAsync(id);

        return result;
    }
}
