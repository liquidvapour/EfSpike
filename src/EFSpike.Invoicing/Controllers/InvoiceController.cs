using Microsoft.AspNetCore.Mvc;

namespace EFSpike.Controllers;

public class InvoiceController : Controller
{
    public ActionResult Index()
    {
        return View();
    }
}