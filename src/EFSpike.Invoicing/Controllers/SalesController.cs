using Microsoft.AspNetCore.Mvc;

namespace EFSpike.Invoicing.Controllers;

[ApiController]
[Route("[controller]")]
public class SalesController : ControllerBase
{
    private readonly SalesContext _salesContext;

    public SalesController(SalesContext salesContext)
    {
        _salesContext = salesContext;
    }
    
    [HttpGet()]
    public Task<IActionResult> Index()
    {
        return Task.FromResult<IActionResult>(Ok(new { InvoiceNumber = 1 }));
    }

    [HttpPost()]
    public async Task<IActionResult> Index(InvoiceDto invoice)
    {
        var customer = new Customer() { };
        _salesContext.Add(customer);
        _salesContext.Add(new Invoice() { Customer = customer });
        await _salesContext.SaveChangesAsync();
        return Ok(new { InvoiceNumber = 1 });
    }
}