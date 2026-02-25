using MultiTenantProject.Data;
using MultiTenantProject.Model;
using MultiTenantProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace MultiTenantProject.BLL
{
    public class InvoiceService:IInvoiceService
    {
        private readonly IRepository<Invoice> _repository;

        public InvoiceService(IRepository<Invoice> repository)
        {
            _repository = repository;
        }

        public async Task<Invoice> CreateAsync(CreateInvoiceDto dto)
        {
            var invoice = new Invoice
            {
                InvoiceNumber = dto.InvoiceNumber,
                CustomerName = dto.CustomerName,
                Amount = dto.Amount,
                DueDate = dto.DueDate
            };

            await _repository.AddAsync(invoice);
            await _repository.SaveChangesAsync();

            return invoice;
        }

        public async Task<List<Invoice>> GetPagedAsync(int page, int pageSize)
        {
            return await _repository.Query()
                .OrderByDescending(i => i.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task SoftDeleteAsync(int id)
        {
            var invoice = await _repository.GetByIdAsync(id);
            if (invoice == null) return;

            invoice.IsDeleted = true;
            await _repository.SaveChangesAsync();
        }
    }
}
