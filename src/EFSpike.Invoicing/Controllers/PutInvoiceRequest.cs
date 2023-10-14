namespace EFSpike.Invoicing.Controllers;

public record PutInvoiceRequest(int? Id, Guid CustomerId, InvoiceItemDto[] items);