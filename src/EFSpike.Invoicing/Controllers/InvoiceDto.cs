namespace EFSpike.Invoicing.Controllers;

public record InvoiceDto(Guid CustomerId, InvoiceItemDto[] items);