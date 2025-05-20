using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.API.ExtensionMethods;

namespace ToDo.API.Mapping;

/// <summary>
/// A class representing a collection of mapping profiles.
/// </summary>
public class MappingProfiles : Profile
{
    // TODO: Add mapping profile properties and methods as needed
    public MappingProfiles()
    {
        this.AddToDoMapping();
    }
    
}
