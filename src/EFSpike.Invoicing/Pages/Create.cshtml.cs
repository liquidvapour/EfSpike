using EFSpike.Invoicing.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFSpike.Invoicing.Views.Invoice;

public class Create : PageModel
{
    private readonly SalesContext _context;

    public Create(SalesContext context)
    {
        _context = context;
    }

    public void OnPost([FromForm]InvoiceDto invoice)
    {
        
    }
    
    public void OnGet()
    {
        Invoice = new InvoiceDto(
            123,
            "CUST123",
            new []
            {
                new InvoiceItemDto(
                    456, 
                    1,
                    "PRD",
                    new decimal(2.33))
            });
    }
    
    public InvoiceDto Invoice { get; set; }
}

public record InvoiceDto(int Id, string CustomerNumber, InvoiceItemDto[] Items);

public record InvoiceItemDto(int Id, int Quantity, string ProductCode, decimal Price);
