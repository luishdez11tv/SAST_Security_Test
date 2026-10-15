using Microsoft.AspNetCore.Mvc;
using SnykCodeLab.Models;
using SnykCodeLab.Services;

namespace SnykCodeLab.Controllers;

[ApiController]
[Route("api/payments")]
public sealed class PaymentsController : ControllerBase
{
    private readonly PaymentService _payments;
    public PaymentsController(PaymentService payments) => _payments = payments;

    [HttpGet]
    public IActionResult List() => Ok(_payments.GetAll());

    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        var payment = _payments.Get(id);
        // LAB VULNERABILITY: payment details exposed without authentication or authorization.
        return payment is null ? NotFound() : Ok(payment);
    }

    [HttpGet("invoice/{invoiceId:int}")]
    public IActionResult ForInvoice(int invoiceId) => Ok(_payments.ForInvoice(invoiceId));

    [HttpPost]
    public IActionResult Register(Payment payment)
    {
        var created = _payments.Register(payment);
        return created is null ? BadRequest("Invalid payment") : Ok(created);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id) =>
        _payments.Delete(id) ? NoContent() : NotFound();
}
