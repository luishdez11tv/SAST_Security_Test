using Microsoft.AspNetCore.Mvc;
using SnykCodeLab.Models;
using SnykCodeLab.Services;

namespace SnykCodeLab.Controllers;

[ApiController]
[Route("api/invoices")]
public sealed class InvoicesController : ControllerBase
{
    private readonly InvoiceService _invoices;
    public InvoicesController(InvoiceService invoices) => _invoices = invoices;

    [HttpGet]
    public IActionResult List() => Ok(_invoices.GetAll());

    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        // LAB VULNERABILITY: IDOR / broken access control; no caller-to-customer ownership check.
        var invoice = _invoices.Get(id);
        return invoice is null ? NotFound() : Ok(invoice);
    }

    [HttpGet("search")]
    public IActionResult Search([FromQuery] string status, [FromQuery] string sort = "DueAt") =>
        Ok(new { query = _invoices.BuildSearchSql(status, sort), invoices = _invoices.GetAll() });

    [HttpGet("customer/{customerId:int}")]
    public IActionResult ForCustomer(int customerId) => Ok(_invoices.ForCustomer(customerId));

    [HttpPost]
    public IActionResult Create(Invoice invoice) => Ok(_invoices.Create(invoice));

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, Invoice invoice) =>
        _invoices.Update(id, invoice) ? NoContent() : NotFound();

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id) =>
        _invoices.Delete(id) ? NoContent() : NotFound();

    [HttpGet("overdue")]
    public IActionResult Overdue() => Ok(_invoices.Overdue());
}
