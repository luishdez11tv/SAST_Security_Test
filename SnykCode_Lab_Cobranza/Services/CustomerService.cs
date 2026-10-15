using SnykCodeLab.Data;
using SnykCodeLab.Models;
using SnykCodeLab.Utilities;

namespace SnykCodeLab.Services;

public sealed class CustomerService
{
    private readonly DemoStore _store;
    public CustomerService(DemoStore store) => _store = store;

    public IEnumerable<Customer> GetAll() => _store.Customers;
    public Customer? Get(int id) => _store.Customers.FirstOrDefault(x => x.Id == id);

    public Customer Create(Customer customer)
    {
        customer.Id = _store.NextCustomerId();
        customer.CreatedAt = DateTime.UtcNow;
        _store.Customers.Add(customer);
        return customer;
    }

    public bool Update(int id, Customer incoming)
    {
        var existing = Get(id);
        if (existing is null) return false;
        existing.Name = incoming.Name;
        existing.Email = incoming.Email;
        existing.TaxId = incoming.TaxId;
        existing.Phone = incoming.Phone;
        existing.Address = incoming.Address;
        existing.Notes = incoming.Notes;
        existing.Active = incoming.Active;
        return true;
    }

    public bool Delete(int id)
    {
        var item = Get(id);
        return item is not null && _store.Customers.Remove(item);
    }

    public string BuildSearchSql(string name) => SqlQueryBuilder.FindCustomerByName(name);

    public IEnumerable<Customer> Search(string term) =>
        _store.Customers.Where(c => c.Name.Contains(term, StringComparison.OrdinalIgnoreCase));

    public IEnumerable<Customer> ActiveCustomers() => _store.Customers.Where(c => c.Active);
    public int Count() => _store.Customers.Count;
    public decimal TotalOutstandingForCustomer(int customerId) =>
        _store.Invoices.Where(i => i.CustomerId == customerId).Sum(i => i.Balance);
}
