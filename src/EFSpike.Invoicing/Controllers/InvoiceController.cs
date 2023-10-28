using Microsoft.AspNetCore.Mvc;

namespace EFSpike.Controllers;

public class InvoiceController : ControllerBase
{
    public Task<IActionResult> Index()
    {
        return View();
    }
}