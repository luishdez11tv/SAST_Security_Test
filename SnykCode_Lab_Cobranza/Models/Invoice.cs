namespace SnykCodeLab.Models;

public sealed class Invoice
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string Folio { get; set; } = "";
    public decimal Amount { get; set; }
    public decimal Balance { get; set; }
    public string Currency { get; set; } = "MXN";
    public string Status { get; set; } = "Pending";
    public DateTime IssuedAt { get; set; } = DateTime.UtcNow;
    public DateTime DueAt { get; set; } = DateTime.UtcNow.AddDays(30);
    public string Description { get; set; } = "";
}
