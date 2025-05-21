
using ToDo.Application.DTOS;
using ToDo.Domain.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MudBlazor;
using System.Net.NetworkInformation;
using System.Security.Authentication;
using System.Text.Json;
using static MudBlazor.CategoryTypes;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;

namespace ToDo.Blazor.Components.Pages.ToDo;

public partial class ToDosPage
{
    private IEnumerable<ToDoDto> ToDoDtos = new List<ToDoDto>();
    public bool _openDrawer { get; set; }
    public CreateUpdateToDoDto CreateUpdateToDo { get; set; } = new();

    public MudDataGrid<ToDoDto> dataGrid { get; set; } = new();
    public Guid toDoId { get; set; }

    //private async Task<GridData<ToDoDto>> ServerReload(GridState<ToDoDto> state)
    //{
       
        
    //    var result = await EmployeeAppService.GetListAsync(input);
    //    Employees = result.Value.Items;
       
    //    return new GridData<EmployeeDto>
    //    {
    //        TotalItems = (int) result.Value.TotalCount,
    //        Items = Employees
    //    };
    //}

    
    //private async Task ViewToDo(Guid id)
    //{
    //    var parameters = new DialogParameters()
    //    {
    //      ["toDoId"] = id 
    //    };
    //    var dialog = await Dialog.ShowAsync<ViewEmployeePage>("ViewEmployee", parameters);
        
    //}
    //private async Task EditToDo(Guid id)
    //{
    //    _openDrawer = true;
    //    toDoId = id;

    //    var toDo = await EmployeeAppService.GetAsync(id);
        
    //    CreateUpdateToDo = Mapper.Map<CreateUpdateToDoDto>(toDo.Value);
    //}    
    
   
    

    //private async Task DeleteEmoloyee(int id)
    //{
    //    var dialog = await Dialog.ShowAsync<DeleteComponent>("DeleteEmployee");
    //    var result = await dialog.Result;
    //    if (!result.Canceled)
    //    {
    //       var IsDeleted = await EmployeeAppService.DeleteAsync(id);
    //        if (IsDeleted.IsSuccess)
    //        {
    //            Snackbar.Add("Employee deleted successfully", MudBlazor.Severity.Success);
    //            await Task.Delay(1000);

    //            NavigationManager.NavigateTo("/employees",true);
    //        }
    //        else
    //        {
    //            foreach (var error in IsDeleted.Errors)
    //            {
    //                Snackbar.Add(error, MudBlazor.Severity.Error);
    //            }

    //        }


    //    }
        

    //}

    //private async Task SubmitEdit()
    //{
    //    var result = await EmployeeAppService.UpdateAsync(EmployeeId, CreateUpdateEmployee);
    //    if (result.IsSuccess)
    //    {
    //        Snackbar.Add("Employee updated successfully", Severity.Success);
    //        NavigationManager.NavigateTo("/employees", true);
    //        _openDrawer = true;
    //        StateHasChanged();

    //    }
    //    else
    //    {
    //        foreach (var error in result.Errors)
    //            {
    //                Snackbar.Add(error, Severity.Error);
    //            }

    //    }
    //}

    //private void CancelEdit()
    //{
    //    CreateUpdateEmployee = new();
    //    _openDrawer = false;
    //    NavigationManager.NavigateTo("/employees", true);

    //}
}
