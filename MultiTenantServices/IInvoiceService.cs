using MultiTenantProject.Model;
using MultiTenantProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiTenantProject.BLL
{
    public interface IInvoiceService
    {
        Task<Invoice> CreateAsync(CreateInvoiceDto dto);
        Task<List<Invoice>> GetPagedAsync(int page, int pageSize);
        Task SoftDeleteAsync(int id);
    }
}
