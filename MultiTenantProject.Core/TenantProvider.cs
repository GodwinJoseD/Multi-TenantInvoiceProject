using Microsoft.AspNetCore.Http;

namespace MultiTenantProject.Core
{
    public class TenantProvider : ITenantProvider
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public TenantProvider(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public int GetTenantId()
        {
            var header = _contextAccessor.HttpContext?
                .Request.Headers["X-Tenant-ID"]
                .FirstOrDefault();

            return int.TryParse(header, out var tenantId) ? tenantId : 0;
        }

    }
}
