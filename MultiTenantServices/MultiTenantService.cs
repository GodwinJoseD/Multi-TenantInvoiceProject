using MultiTenantProject.BLL;
using MultiTenantProject.Core;
using MultiTenantProject.Data;
using MultiTenantProject.Model;

namespace MultiTenantProject.BLL
{
    public class MultiTenantService:IMultiTenantService
    {
        private readonly AppDbContext _context;
        private readonly ITenantProvider _tenantProvider;

        public MultiTenantService(AppDbContext context,
                              ITenantProvider tenantProvider)
        {
            _context = context;
            _tenantProvider = tenantProvider;
        }

        public List<Project> GetAll()
        {
            return _context.Projects.ToList();
        }

        public Project Create(string name)
        {
            var project = new Project
            {
                Name = name,
                TenantId = _tenantProvider.GetTenantId()
            };

            _context.Projects.Add(project);
            _context.SaveChanges();

            return project;
        }
    }
}
