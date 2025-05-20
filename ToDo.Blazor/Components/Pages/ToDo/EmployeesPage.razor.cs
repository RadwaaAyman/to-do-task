using DocumentFormat.OpenXml.Office2021.Excel.NamedSheetViews;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using HrModule.Application.DTOS.Employees;
using HrModule.Blazor.Components.Pages.SharedComponents;
using HrModule.Domain.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MudBlazor;
using SharedKernel.AlertMessages;
using SharedKernel.DataGrid_Table;
using SharedKernel.Dtos;
using SharedKernel.Entities;
using SharedKernel.HelperMethods;
using System.Net.NetworkInformation;
using System.Security.Authentication;
using System.Text.Json;
using static MudBlazor.CategoryTypes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HrModule.Blazor.Components.Pages.Employees;

public partial class EmployeesPage
{
    private IEnumerable<EmployeeDto> Employees = new List<EmployeeDto>();
    private string _searchString;
    public bool _openDrawer { get; set; }
    public CreateUpdateEmployeeDto CreateUpdateEmployee { get; set; } = new();

    public MudDataGrid<EmployeeDto> dataGrid { get; set; } = new();
    public int EmployeeId { get; set; }

    private async Task<GridData<EmployeeDto>> ServerReload(GridState<EmployeeDto> state)
    {
        var input = new PagedResultRequestDto
        {
            PageSize = state.PageSize,
            PageCount = state.Page + 1,
            SearchingTerm = _searchString,
            SkipCount = ((state.Page + 1) - 1) * state.PageSize,
            Sorting = "",

        };
        var sortDefinition = state.SortDefinitions.FirstOrDefault();
        if (sortDefinition != null)
        {
            input.Sorting =sortDefinition.SortBy;
            input.IsDescending = sortDefinition.Descending;
        }
        
        
        var result = await EmployeeAppService.GetListAsync(input);
        Employees = result.Value.Items;
       
        return new GridData<EmployeeDto>
        {
            TotalItems = (int) result.Value.TotalCount,
            Items = Employees
        };
    }
    private async Task OnSearching(string searchString)
    {
       _searchString = searchString;
       await dataGrid.ReloadServerData();
    }   
    

    private void CreateCustomer()
    {
        NavigationManager.NavigateTo("/employees/add");
    }

    private async Task ViewEmoloyee(int id)
    {
        var parameters = new DialogParameters()
        {
          ["EmployeeId"] = id 
        };
        var dialog = await Dialog.ShowAsync<ViewEmployeePage>("ViewEmployee", parameters);
        
    }
    private async Task EditEmoloyee(int id)
    {
        _openDrawer = true;
        EmployeeId = id;
        var employee = await EmployeeAppService.GetAsync(id);
        
        CreateUpdateEmployee = Mapper.Map<CreateUpdateEmployeeDto>(employee.Value);
    }    
    
   
    

    private async Task DeleteEmoloyee(int id)
    {
        var dialog = await Dialog.ShowAsync<DeleteComponent>("DeleteEmployee");
        var result = await dialog.Result;
        if (!result.Canceled)
        {
           var IsDeleted = await EmployeeAppService.DeleteAsync(id);
            if (IsDeleted.IsSuccess)
            {
                Snackbar.Add("Employee deleted successfully", MudBlazor.Severity.Success);
                await Task.Delay(1000);

                NavigationManager.NavigateTo("/employees",true);
            }
            else
            {
                foreach (var error in IsDeleted.Errors)
                {
                    Snackbar.Add(error, MudBlazor.Severity.Error);
                }

            }


        }
        

    }

    private async Task SubmitEdit()
    {
        var result = await EmployeeAppService.UpdateAsync(EmployeeId, CreateUpdateEmployee);
        if (result.IsSuccess)
        {
            Snackbar.Add("Employee updated successfully", Severity.Success);
            NavigationManager.NavigateTo("/employees", true);
            _openDrawer = true;
            StateHasChanged();

        }
        else
        {
            foreach (var error in result.Errors)
                {
                    Snackbar.Add(error, Severity.Error);
                }

        }
    }

    private void CancelEdit()
    {
        CreateUpdateEmployee = new();
        _openDrawer = false;
        NavigationManager.NavigateTo("/employees", true);

    }
}
