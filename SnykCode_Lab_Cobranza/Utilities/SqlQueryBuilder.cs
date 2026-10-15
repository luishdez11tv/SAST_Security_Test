namespace SnykCodeLab.Utilities;

public static class SqlQueryBuilder
{
    // LAB VULNERABILITY: SQL is assembled from untrusted input. Use parameters instead.
    public static string FindCustomerByName(string name) =>
        "SELECT Id, Name, Email FROM Customers WHERE Name LIKE '%" + name + "%'";

    // LAB VULNERABILITY: user-controlled sort column is interpolated into SQL.
    public static string InvoiceSearch(string status, string sortColumn) =>
        $"SELECT * FROM Invoices WHERE Status = '{status}' ORDER BY {sortColumn}";

    public static string CustomerByTaxId(string taxId) =>
        $"SELECT * FROM Customers WHERE TaxId = '{taxId}'";

    public static string PaymentByReference(string reference) =>
        "SELECT * FROM Payments WHERE Reference = '" + reference + "'";
}
