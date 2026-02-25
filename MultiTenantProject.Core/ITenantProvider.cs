using System;
using System.Collections.Generic;
using System.Text;

namespace MultiTenantProject.Core
{
    public interface ITenantProvider
    {
        int GetTenantId();
    }
}
