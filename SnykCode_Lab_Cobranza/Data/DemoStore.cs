using SnykCodeLab.Models;

namespace SnykCodeLab.Data;

// In-memory storage keeps the lab self-contained; this is not a production persistence layer.
public sealed class DemoStore
{
    public List<Customer> Customers { get; } = new();
    public List<Invoice> Invoices { get; } = new();
    public List<Payment> Payments { get; } = new();
    public List<PortalUser> Users { get; } = new();
    private int _customerId = 3;
    private int _invoiceId = 3;
    private int _paymentId = 1;

    public DemoStore()
    {
        Customers.Add(new Customer { Id = 1, Name = "Comercial Norte", Email = "cuentas@norte.example", TaxId = "XAXX010101000", Phone = "555-0101", Address = "Av. Central 100" });
        Customers.Add(new Customer { Id = 2, Name = "Servicios del Bajío", Email = "pagos@bajio.example", TaxId = "XEXX010101000", Phone = "555-0102", Address = "Calle Sur 220" });
        Invoices.Add(new Invoice { Id = 1, CustomerId = 1, Folio = "FAC-1001", Amount = 12500m, Balance = 12500m, Description = "Servicios mensuales" });
        Invoices.Add(new Invoice { Id = 2, CustomerId = 2, Folio = "FAC-1002", Amount = 8700m, Balance = 8700m, Description = "Soporte técnico" });
        Users.Add(new PortalUser { Id = 1, Username = "admin", PasswordHash = "admin123", Role = "Administrator", CustomerId = 0 });
        Users.Add(new PortalUser { Id = 2, Username = "cliente1", PasswordHash = "cliente123", Role = "Customer", CustomerId = 1 });
    }

    public int NextCustomerId() => _customerId++;
    public int NextInvoiceId() => _invoiceId++;
    public int NextPaymentId() => _paymentId++;
}
