using EFSpike.Invoicing.Controllers;
using EFSpike.Invoicing.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EFSpike.Invoicing.Views.Invoice;

public class Index : PageModel
{
    private readonly SalesContext _context;
    public Index(SalesContext context)
    {
        _context = context;
    }
    
    public List<Data.Invoice>? Invoice { get; set; }
    
    public async Task OnGet()
    {
        Invoice ??= await _context.Invoices.ToListAsync();
    }}

