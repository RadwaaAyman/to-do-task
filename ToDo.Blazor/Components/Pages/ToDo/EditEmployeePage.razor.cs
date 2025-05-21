using ToDo.Application.DTOS;
using Microsoft.AspNetCore.Components;

namespace ToDo.Blazor.Components.Pages.ToDo;

public partial class EditToDoPage
{
    [Parameter]
    public bool _open { get; set; }

    [Parameter]
    public CreateUpdateToDoDto CreateUpdateToDoDto { get; set; }

    [Parameter]
    public EventCallback Cancel { get; set; }

    [Parameter]
    public EventCallback Submit { get; set; }
}
