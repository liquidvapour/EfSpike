using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFSpike.Invoicing.Controllers;

public record GetInvoicesResponseDto(GetInvoiceResponseDto[] Invoices)
{
    public override string ToString()
    {
        return $"{{ Invoices = {Invoices} }}";
    }
}


[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class SalesController : ControllerBase
{
    private readonly SalesContext _salesContext;

    public SalesController(SalesContext salesContext)
    {
        _salesContext = salesContext;
    }


    [HttpGet]
    [ProducesResponseType(typeof(GetInvoicesResponseDto), 200, "application/json")]
    public async Task<IActionResult> Index()
    {
        return Ok(await GetInvoicesResponse());
    }

    private async Task<GetInvoicesResponseDto> GetInvoicesResponse() =>
        new(
            await _salesContext.Invoices.Select(x =>
                new GetInvoiceResponseDto(
                    x.Id!.Value,
                    x.Customer.Id,
                    x.Items.Select(y => new GetInvoiceItemResponseDto(
                        y.Id!.Value,
                        y.Quantity,
                        y.ProductCode)).ToArray())).ToArrayAsync());

    [HttpPost]
    public async Task<IActionResult> Index(PutInvoiceRequestDto invoice)
    {
        
        var customer = await _salesContext.Customers.FindAsync(invoice.CustomerId);
        if (customer == null)
        {
            return BadRequest(new ProblemDetails
            {
                Title = "No Customer found",
            });
        }

        var invoiceData = new Invoice
        {
            Customer = customer,
            Items = invoice.items.Select(x =>
                    new InvoiceItem
                    {
                        Id = x.Id,
                        ProductCode = x.ProductCode,
                        Quantity = x.Quantity
                    })
                .ToList()
        };
        if (invoice.Id is null)
        {
            _salesContext.Add(invoiceData);
        }
        else
        {
            var existingInvoiceData = await _salesContext.Invoices
                .Include(x => x.Items)
                .FirstOrDefaultAsync(x => x.Id == invoice.Id);

            existingInvoiceData.Customer = customer;
            var itemsToAdd = new List<InvoiceItem>();
            foreach (var item in invoiceData.Items)
            {
                var oldItem = existingInvoiceData.Items.FirstOrDefault(x => x.Id == item.Id);
                if (oldItem != null)
                {
                    oldItem.ProductCode = item.ProductCode;
                    oldItem.Quantity = item.Quantity;
                }
                else
                {
                    itemsToAdd.Add(item);
                }
            }
            existingInvoiceData.Items.AddRange(itemsToAdd);
        }
        
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