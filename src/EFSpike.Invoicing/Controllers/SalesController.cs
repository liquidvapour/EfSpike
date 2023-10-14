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

    [HttpGet]
    public Task<IActionResult> Index()
    {
        var invoices = _salesContext.Invoices.Select(x =>
            new InvoiceDto(
                x.Id!.Value,
                x.Customer.Id,
                x.Items.Select(y => new InvoiceItemDto(y.Id!.Value, y.Quantity, y.ProductCode)).ToArray()));
        return Task.FromResult<IActionResult>(Ok(new { Invoices = invoices }));
    }

    [HttpPost]
    public async Task<IActionResult> Index(InvoiceDto invoice)
    {
        var customer = new Customer { };
        _salesContext.Add(customer);
        _salesContext.Add(new Invoice
        {
            Customer = customer,
            Items = invoice.items.Select(x =>
                    new InvoiceItem
                    {
                        ProductCode = x.ProductCode,
                        Quantity = x.Quantity
                    })
                .ToList()
        });
        await _salesContext.SaveChangesAsync();
        return Ok(new { InvoiceNumber = 1 });
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> Customers()
    {
        var customers = _salesContext.Customers.Select(x =>
            new CustomerDto(x.Id)).ToArray();

        return Ok(new { Customers = customers });
    }
}

public record CustomerDto(Guid Id);