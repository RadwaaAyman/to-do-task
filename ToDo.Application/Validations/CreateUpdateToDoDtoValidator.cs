using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDo.Application.DTOS;

namespace ToDo.Application.Validations;

/// <summary>
/// Validator for CreateUpdateToDoDto.
/// </summary>
public class CreateUpdateToDoDtoValidator : AbstractValidator<CreateUpdateToDoDto>
{
    /// <summary>
    /// Initializes a new instance of the CreateUpdateToDoDtoValidator class.
    /// </summary>
    public CreateUpdateToDoDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .Matches(@"^[a-zA-Z]+$").WithMessage("First name must contain only English letters.")
            .Length(5, 100).WithMessage("Title must be between 5 and 100 characters.");


        RuleFor(x => x.Description)
            .Matches(@"^[a-zA-Z]+$").WithMessage("First name must contain only English letters.")
            .Length(10, 150).WithMessage("Description must be between 10 and 150 characters.");
        
        RuleFor(x => x.Priority)
            .IsInEnum().WithMessage("Please select a valid priority.");

        RuleFor(x => x.DueDate)
            .Must(dueDate => dueDate >= DateTime.Now)
            .WithMessage("Due Date must be from today or more.");

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Please select a valid status.");
    }
}
