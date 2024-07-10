namespace EFSpike.Invoicing.Controllers;

public record PutInvoiceRequestDto(int? Id, Guid CustomerId, InvoiceItemDto[] items);
public record GetInvoiceResponseDto(int? Id, Guid CustomerId, GetInvoiceItemResponseDto[] items);
public record GetInvoiceItemResponseDto(int Id, string ProductCode, decimal Quantity, decimal Price, decimal LinePrice);