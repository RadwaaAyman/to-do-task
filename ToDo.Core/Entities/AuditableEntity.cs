using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Core.Entities;

public class AuditableEntity : BaseEntity
{
    public DateTime CreatedDate { get; set; }
    public DateTime LastModifiedDate { get; set; }
}
