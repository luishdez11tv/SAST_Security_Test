using System.Text;
using SnykCodeLab.Data;
using SnykCodeLab.Models;

namespace SnykCodeLab.Services;

public sealed class ReportService
{
    private readonly DemoStore _store;
    public ReportService(DemoStore store) => _store = store;

    public object Dashboard() => new
    {
        customers = _store.Customers.Count,
        invoices = _store.Invoices.Count,
        billed = _store.Invoices.Sum(x => x.Amount),
        outstanding = _store.Invoices.Sum(x => x.Balance),
        collected = _store.Payments.Sum(x => x.Amount)
    };

    public string BuildCsv()
    {
        var sb = new StringBuilder();
        sb.AppendLine("Invoice,Folio,Customer,Amount,Balance,Status");
        foreach (var invoice in _store.Invoices)
        {
            var customer = _store.Customers.FirstOrDefault(c => c.Id == invoice.CustomerId);
            // LAB VULNERABILITY: CSV formula injection if attacker-controlled fields begin with =, +, -, or @.
            sb.AppendLine($"{invoice.Id},{invoice.Folio},{customer?.Name},{invoice.Amount},{invoice.Balance},{invoice.Status}");
        }
        return sb.ToString();
    }

    public IEnumerable<object> AgingReport()
    {
        var today = DateTime.UtcNow.Date;
        return _store.Invoices.Where(i => i.Balance > 0)
            .Select(i => new
            {
                i.Folio,
                i.CustomerId,
                i.Balance,
                DaysLate = Math.Max(0, (today - i.DueAt.Date).Days)
            });
    }

    public IEnumerable<object> CustomerBalances() =>
        _store.Customers.Select(c => new
        {
            c.Id,
            c.Name,
            Balance = _store.Invoices.Where(i => i.CustomerId == c.Id).Sum(i => i.Balance)
        });
}
