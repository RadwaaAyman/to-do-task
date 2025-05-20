using ToDo.Application.DTOS;
using MudBlazor;
using ToDo.Application.Services;

namespace ToDo.Blazor.Components.Pages.ToDo;

public partial class AddTDoPage
{
    private MudForm? form;

    private CreateUpdateToDoDto createUpdateToDoDto = new();

    private string CheckDueDate(DateTime? dateTime)
    {

        if (dateTime >= DateTime.Now)
            return "Due Date must be from today or more.";

        return string.Empty;
    }

    private async Task SubmitForm()
    {
        var result = await ToDoService(createUpdateToDoDto);

        if (result.IsSuccess)

        {

            Snackbar.Add("Employee added successfully", MudBlazor.Severity.Success);

            Navigation.NavigateTo("/employees");

        }
        else
        {
            foreach (var error in result.Errors)
            {
                Snackbar.Add(error, MudBlazor.Severity.Error);
            }

        }






    }

    private void Cancel()

    {

        Navigation.NavigateTo("/todos");

    }
}
