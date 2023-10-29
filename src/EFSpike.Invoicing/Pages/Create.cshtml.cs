using EFSpike.Invoicing.Controllers;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EFSpike.Invoicing.Views.Invoice;

public class Create : PageModel
{
    private readonly SalesContext _context;

    public Create(SalesContext context)
    {
        _context = context;
    }
    
    public void OnGet()
    {
        Invoice = new Controllers.Invoice();
    }
    
    public Controllers.Invoice Invoice { get; set; }
}