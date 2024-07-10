using EFSpike.Invoicing.Controllers;

namespace EFSpike.Invoicing.Data;

public class Invoice
{
    public int? Id { get; set; }
    public Customer? Customer { get; set; }
    public string CustomerNumber { get; set; }
    public List<InvoiceItem> Items { get; set; } = new();
}