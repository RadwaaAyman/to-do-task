using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Contracts;
using ToDo.Application.DTOS;
using ToDo.Application.Validations;
using ToDo.Core.Result;
using ToDo.Domain.Entities;
using ToDo.Infrastructure.DbContexts;

namespace ToDo.Application.Services;

public class ToDoService(ToDoDbContext dbContext , IMapper mapper , IValidator<CreateUpdateToDoDto> validator) : IToDoService
{
    private readonly ToDoDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;
    private readonly IValidator<CreateUpdateToDoDto> _validator = validator;

    ///<inheritdoc/>
    public async Task<Result<ToDoDto>> CreateAsync(CreateUpdateToDoDto createUpdateToDoDto)
    {
        var validationResults = await _validator.ValidateAsync(createUpdateToDoDto);
        if (!validationResults.IsValid)
        {
            return Result.Error(validationResults.Errors.First().ErrorMessage);
        }

        var errorMessage = await CheckForExistingToDoAsync(createUpdateToDoDto);
        
        if (errorMessage != null)
        {
            return Result.Error(errorMessage);
        }

        var toDo = _mapper.Map<ToDoEntity>(createUpdateToDoDto);


        _dbContext.ToDos.Add(toDo);
        
        await _dbContext.SaveChangesAsync();
        
        var toDoDto = _mapper.Map<ToDoDto>(toDo);
        
        return Result.Success(toDoDto, "ToDo added successfully!");
    }

    ///<inheritdoc/>
    public async Task<Result<string>> DeleteAsync(Guid id)
    {
        var toDo = await _dbContext.ToDos.FirstOrDefaultAsync(td => td.Id == id);
        
        if (toDo is null)
        {
            return Result.NotFound("No ToDo found.");
        }

        _dbContext.ToDos.Update(toDo);
       
        _dbContext.SaveChanges();
        
        return Result.Success("ToDo deleted successfully.");
    }

    ///<inheritdoc/>
    public async Task<Result<ToDoDto>> GetAsync(Guid id)
    {
        var toDos = await _dbContext.ToDos.FirstOrDefaultAsync(td => td.Id == id );
       
        if (toDos is null)
        {
            return Result.NotFound("No toDo found.");
        }
        var employeeDto = _mapper.Map<ToDoDto>(toDos);

        return Result.Success(employeeDto);
    }

    ///<inheritdoc/>
    public async Task<Result<List<ToDoDto>>> GetListAsync()
    {

        var toDosList = await _dbContext.ToDos.ToListAsync();

        if (toDosList is null)
        {
            return Result.NotFound("No toDo found.");
        }

        var toDoDtos = _mapper.Map<List<ToDoDto>>(toDosList);

        return Result.Success(toDoDtos);
    }

    ///<inheritdoc/>
    public async Task<Result<string>> UpdateAsync(Guid id, CreateUpdateToDoDto createUpdateToDoDto)
    {
        var toDo = await _dbContext.ToDos.FirstOrDefaultAsync(td => td.Id == id);
        
        if (toDo is null)
        {
            return Result.NotFound("No toDo found.");
        }
        var validationResults = await _validator.ValidateAsync(createUpdateToDoDto);
        
        if (!validationResults.IsValid)
        {
            return Result.Error(validationResults.Errors.First().ErrorMessage);
        }
        
        toDo = _mapper.Map(createUpdateToDoDto, toDo);
        
         _dbContext.ToDos.Update(toDo);
        
        _dbContext.SaveChanges();
        
        return Result.Success("ToDo updated successfully.");
    }
 

    private async Task<string?> CheckForExistingToDoAsync(CreateUpdateToDoDto createUpdateToDoDto)
    {
        if (await _dbContext.ToDos.AnyAsync(e => e.Title == createUpdateToDoDto.Title))
        {
            return "Title already exists.";
        }


        return null;
    }
}
