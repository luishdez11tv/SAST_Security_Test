using Microsoft.AspNetCore.Mvc;
using SnykCodeLab.Models;
using SnykCodeLab.Services;

namespace SnykCodeLab.Controllers;

[ApiController]
[Route("api/customers")]
public sealed class CustomersController : ControllerBase
{
    private readonly CustomerService _customers;
    public CustomersController(CustomerService customers) => _customers = customers;

    [HttpGet]
    public IActionResult List() => Ok(_customers.GetAll());

    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        var customer = _customers.Get(id);
        return customer is null ? NotFound() : Ok(customer);
    }

    [HttpGet("search")]
    public IActionResult Search([FromQuery] string q)
    {
        // LAB VULNERABILITY: unescaped user input is reflected in a response header.
        Response.Headers["X-Search-Term"] = q;
        return Ok(new { sqlPreview = _customers.BuildSearchSql(q), results = _customers.Search(q) });
    }

    [HttpPost]
    public IActionResult Create(Customer customer) => Ok(_customers.Create(customer));

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, Customer customer) =>
        _customers.Update(id, customer) ? NoContent() : NotFound();

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id) =>
        _customers.Delete(id) ? NoContent() : NotFound();
}
