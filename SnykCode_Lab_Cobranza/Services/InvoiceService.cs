using SnykCodeLab.Data;
using SnykCodeLab.Models;
using SnykCodeLab.Utilities;

namespace SnykCodeLab.Services;

public sealed class InvoiceService
{
    private readonly DemoStore _store;
    public InvoiceService(DemoStore store) => _store = store;

    public IEnumerable<Invoice> GetAll() => _store.Invoices;
    public Invoice? Get(int id) => _store.Invoices.FirstOrDefault(x => x.Id == id);

    public Invoice Create(Invoice invoice)
    {
        invoice.Id = _store.NextInvoiceId();
        invoice.Folio = string.IsNullOrWhiteSpace(invoice.Folio) ? $"FAC-{1000 + invoice.Id}" : invoice.Folio;
        invoice.Balance = invoice.Amount;
        invoice.IssuedAt = DateTime.UtcNow;
        _store.Invoices.Add(invoice);
        return invoice;
    }

    public bool Update(int id, Invoice incoming)
    {
        var existing = Get(id);
        if (existing is null) return false;
        existing.CustomerId = incoming.CustomerId;
        existing.Amount = incoming.Amount;
        existing.Balance = incoming.Balance;
        existing.Status = incoming.Status;
        existing.DueAt = incoming.DueAt;
        existing.Description = incoming.Description;
        return true;
    }

    public bool Delete(int id)
    {
        var item = Get(id);
        return item is not null && _store.Invoices.Remove(item);
    }

    public IEnumerable<Invoice> ForCustomer(int customerId) =>
        _store.Invoices.Where(i => i.CustomerId == customerId);

    public IEnumerable<Invoice> Overdue(DateTime? today = null)
    {
        var date = today ?? DateTime.UtcNow.Date;
        return _store.Invoices.Where(i => i.Balance > 0 && i.DueAt.Date < date);
    }

    public decimal TotalOutstanding() => _store.Invoices.Sum(i => i.Balance);
    public decimal TotalBilled() => _store.Invoices.Sum(i => i.Amount);
    public string BuildSearchSql(string status, string sortColumn) =>
        SqlQueryBuilder.InvoiceSearch(status, sortColumn);
}
