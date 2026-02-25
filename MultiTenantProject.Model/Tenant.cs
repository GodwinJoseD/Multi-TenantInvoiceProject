using System;
using System.Collections.Generic;
using System.Text;

namespace MultiTenantProject.Model
{
    public class Tenant
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
