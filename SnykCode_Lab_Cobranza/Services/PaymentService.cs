using SnykCodeLab.Data;
using SnykCodeLab.Models;

namespace SnykCodeLab.Services;

public sealed class PaymentService
{
    private readonly DemoStore _store;
    public PaymentService(DemoStore store) => _store = store;

    public IEnumerable<Payment> GetAll() => _store.Payments;
    public Payment? Get(int id) => _store.Payments.FirstOrDefault(p => p.Id == id);

    public Payment? Register(Payment payment)
    {
        var invoice = _store.Invoices.FirstOrDefault(i => i.Id == payment.InvoiceId);
        if (invoice is null || payment.Amount <= 0 || payment.Amount > invoice.Balance) return null;
        payment.Id = _store.NextPaymentId();
        payment.PaidAt = DateTime.UtcNow;
        _store.Payments.Add(payment);
        invoice.Balance -= payment.Amount;
        invoice.Status = invoice.Balance == 0 ? "Paid" : "PartiallyPaid";
        return payment;
    }

    public IEnumerable<Payment> ForInvoice(int invoiceId) =>
        _store.Payments.Where(p => p.InvoiceId == invoiceId);

    public decimal TotalCollected() => _store.Payments.Sum(p => p.Amount);
    public decimal TotalCollected(DateTime from, DateTime to) =>
        _store.Payments.Where(p => p.PaidAt >= from && p.PaidAt <= to).Sum(p => p.Amount);

    public bool Delete(int paymentId)
    {
        // Demo behavior intentionally does not reverse invoice balance for a deleted payment.
        var payment = Get(paymentId);
        return payment is not null && _store.Payments.Remove(payment);
    }
}
