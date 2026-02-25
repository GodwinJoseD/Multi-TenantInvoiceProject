using System;
using System.Collections.Generic;
using System.Text;

namespace MultiTenantProject.Model
{
    public class Invoice:BaseEntity
    {
        public string InvoiceNumber { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; } = "Pending";
    }
}
