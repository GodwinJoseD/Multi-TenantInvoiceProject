using System;
using System.Collections.Generic;
using System.Text;

namespace MultiTenantProject.Model
{
    public class Project:BaseEntity
    {
        public string Name { get; set; } = string.Empty;
    }
}
