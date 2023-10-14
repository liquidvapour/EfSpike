namespace EFSpike.Invoicing.Controllers;

public record InvoiceDto(int Id, Guid CustomerId, InvoiceItemDto[] items);