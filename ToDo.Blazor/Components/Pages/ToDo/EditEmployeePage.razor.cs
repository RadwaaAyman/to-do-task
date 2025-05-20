using HrModule.Application.DTOS.Employees;
using Microsoft.AspNetCore.Components;

namespace HrModule.Blazor.Components.Pages.Employees;

public partial class EditEmployeePage
{
    [Parameter]
    public bool _open { get; set; }

    [Parameter]
    public CreateUpdateEmployeeDto CreateUpdateEmployeeDto { get; set; }

    [Parameter]
    public EventCallback Cancel { get; set; }

    [Parameter]
    public EventCallback Submit { get; set; }
}
