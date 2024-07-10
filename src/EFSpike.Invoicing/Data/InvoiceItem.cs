namespace EFSpike.Invoicing.Data;

public class InvoiceItem
{
    public int? Id { get; set; }
    public string InvoiceNo { get; set; }
    public decimal Quantity { get; set; }
    public string ProductCode { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal LinePrice { get; set; }
}