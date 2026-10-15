using Microsoft.AspNetCore.Mvc;
using SnykCodeLab.Services;
using SnykCodeLab.Utilities;

namespace SnykCodeLab.Controllers;

[ApiController]
[Route("api/reports")]
public sealed class ReportsController : ControllerBase
{
    private readonly ReportService _reports;
    private readonly ExportService _exports = new();
    public ReportsController(ReportService reports) => _reports = reports;

    [HttpGet("dashboard")]
    public IActionResult Dashboard() => Ok(_reports.Dashboard());

    [HttpGet("aging")]
    public IActionResult Aging() => Ok(_reports.AgingReport());

    [HttpGet("balances")]
    public IActionResult Balances() => Ok(_reports.CustomerBalances());

    [HttpGet("export")]
    public IActionResult Export([FromQuery] string file = "invoices.csv")
    {
        var path = _exports.Export(file, _reports.BuildCsv());
        // LAB VULNERABILITY: full server filesystem path is disclosed to the caller.
        return Ok(new { savedTo = path });
    }

    [HttpGet("download")]
    public IActionResult Download([FromQuery] string file)
    {
        // LAB VULNERABILITY: attacker-controlled path is passed to file read helper.
        return Content(_exports.ReadExport(file), "text/plain");
    }
}
