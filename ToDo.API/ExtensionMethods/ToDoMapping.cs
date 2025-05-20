using ToDo.API.Mapping;

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
        map.CreateMap<CreateUpdateEmployeeDto, Employee>().ReverseMap();
        map.CreateMap<Employee, EmployeeDto>().ReverseMap();
        map.CreateMap<CreateUpdateEmployeeDto, EmployeeDto>().ReverseMap();

    }
}