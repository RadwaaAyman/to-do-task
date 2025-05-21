using ToDo.API.Mapping;
using ToDo.Application.DTOS;
using ToDo.Domain.Entities;

namespace ToDo.API.ExtensionMethods;

/// <summary>
/// Provides a static class for mapping toDo-related data.
/// </summary>
public static class ToDoMapping
{
    /// <summary>
    /// Adds todo mapping to the specified mapping profile.
    /// </summary>
    /// <param name="map">The mapping profile to add todo mapping to.</param>
    public static void AddToDoMapping(this MappingProfiles map)
    {
        // TO DO: implement employee mapping logic
        map.CreateMap<CreateUpdateToDoDto, ToDoEntity>();
        map.CreateMap<ToDoEntity, ToDoDto>();
        map.CreateMap<CreateUpdateToDoDto, ToDoDto>();

    }
}