namespace EFSpike.Invoicing.Controllers;

public class InvoiceItem
{
    public int? Id { get; set; }
    public int InvoiceNo { get; set; }
    public int Quantity { get; set; }
}