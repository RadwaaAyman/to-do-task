using HrModule.Application.DTOS.Employees;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HrModule.Blazor.Components.Pages.Employees;

public partial class ViewEmployeePage
{
    [Parameter] public int EmployeeId { get; set; }
    public EmployeeDto EmployeeDto { get; set; } = new();
    protected override async Task OnInitializedAsync()
    {
        var employee = await EmployeeAppService.GetAsync(EmployeeId);
          EmployeeDto = employee.Value;
        
        await base.OnInitializedAsync();
    }

    private void Cancel()
    {

        NavigationManager.NavigateTo("/employees");

    }
}
