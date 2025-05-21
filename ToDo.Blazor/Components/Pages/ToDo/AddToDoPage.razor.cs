using ToDo.Application.DTOS;
using MudBlazor;

namespace ToDo.Blazor.Components.Pages.ToDo;

public partial class AddToDoPage
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
        var result = await ToDoAppService.CreateAsync(createUpdateToDoDto);

        if (result.IsSuccess)

        {

            Snackbar.Add("To Do added successfully", MudBlazor.Severity.Success);

            Navigation.NavigateTo("/todo");

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
