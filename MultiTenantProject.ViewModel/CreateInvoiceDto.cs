namespace MultiTenantProject.ViewModel
{
    public class CreateInvoiceDto
    {
        public string InvoiceNumber { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
    }
}
