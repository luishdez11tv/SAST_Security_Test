namespace SnykCodeLab.Models;

public sealed class Payment
{
    public int Id { get; set; }
    public int InvoiceId { get; set; }
    public decimal Amount { get; set; }
    public string Method { get; set; } = "Transfer";
    public string Reference { get; set; } = "";
    public string ReceivedBy { get; set; } = "";
    public DateTime PaidAt { get; set; } = DateTime.UtcNow;
    public string Status { get; set; } = "Received";
}
