using MultiTenantProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiTenantProject.BLL
{
    public interface IMultiTenantService
    {
        List<Project> GetAll();
        Project Create(string name);
    }
}
