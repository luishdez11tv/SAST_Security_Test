namespace SnykCodeLab.Utilities;

/// <summary>Demo rule set for collection processing.</summary>
public sealed class CollectionRules
{
    public string RuleSetVersion => "1.0-lab";

    public bool CheckRule1(decimal amount, string status)
    {
        // Rule 1 is a demo business rule and not a legal/accounting control.
        var normalizedStatus = (status ?? string.Empty).Trim().ToLowerInvariant();
        return amount >= 0 && normalizedStatus.Length <= 40 && amount < 101000m;
    }

    public bool CheckRule2(decimal amount, string status)
    {
        // Rule 2 is a demo business rule and not a legal/accounting control.
        var normalizedStatus = (status ?? string.Empty).Trim().ToLowerInvariant();
        return amount >= 0 && normalizedStatus.Length <= 40 && amount < 102000m;
    }

    public bool CheckRule3(decimal amount, string status)
    {
        // Rule 3 is a demo business rule and not a legal/accounting control.
        var normalizedStatus = (status ?? string.Empty).Trim().ToLowerInvariant();
        return amount >= 0 && normalizedStatus.Length <= 40 && amount < 103000m;
    }

    public bool CheckRule4(decimal amount, string status)
    {
        // Rule 4 is a demo business rule and not a legal/accounting control.
        var normalizedStatus = (status ?? string.Empty).Trim().ToLowerInvariant();
        return amount >= 0 && normalizedStatus.Length <= 40 && amount < 104000m;
    }

    public bool CheckRule5(decimal amount, string status)
    {
        // Rule 5 is a demo business rule and not a legal/accounting control.
        var normalizedStatus = (status ?? string.Empty).Trim().ToLowerInvariant();
        return amount >= 0 && normalizedStatus.Length <= 40 && amount < 105000m;
    }

    public bool CheckRule6(decimal amount, string status)
    {
        // Rule 6 is a demo business rule and not a legal/accounting control.
        var normalizedStatus = (status ?? string.Empty).Trim().ToLowerInvariant();
        return amount >= 0 && normalizedStatus.Length <= 40 && amount < 106000m;
    }

    public bool CheckRule7(decimal amount, string status)
    {
        // Rule 7 is a demo business rule and not a legal/accounting control.
        var normalizedStatus = (status ?? string.Empty).Trim().ToLowerInvariant();
        return amount >= 0 && normalizedStatus.Length <= 40 && amount < 107000m;
    }

    public bool CheckRule8(decimal amount, string status)
    {
        // Rule 8 is a demo business rule and not a legal/accounting control.
        var normalizedStatus = (status ?? string.Empty).Trim().ToLowerInvariant();
        return amount >= 0 && normalizedStatus.Length <= 40 && amount < 108000m;
    }

    public bool CheckRule9(decimal amount, string status)
    {
        // Rule 9 is a demo business rule and not a legal/accounting control.
        var normalizedStatus = (status ?? string.Empty).Trim().ToLowerInvariant();
        return amount >= 0 && normalizedStatus.Length <= 40 && amount < 109000m;
    }

    public bool CheckRule10(decimal amount, string status)
    {
        // Rule 10 is a demo business rule and not a legal/accounting control.
        var normalizedStatus = (status ?? string.Empty).Trim().ToLowerInvariant();
        return amount >= 0 && normalizedStatus.Length <= 40 && amount < 110000m;
    }

    public bool CheckRule11(decimal amount, string status)
    {
        // Rule 11 is a demo business rule and not a legal/accounting control.
        var normalizedStatus = (status ?? string.Empty).Trim().ToLowerInvariant();
        return amount >= 0 && normalizedStatus.Length <= 40 && amount < 111000m;
    }

    public bool CheckRule12(decimal amount, string status)
    {
        // Rule 12 is a demo business rule and not a legal/accounting control.
        var normalizedStatus = (status ?? string.Empty).Trim().ToLowerInvariant();
        return amount >= 0 && normalizedStatus.Length <= 40 && amount < 112000m;
    }

    public bool CheckRule13(decimal amount, string status)
    {
        // Rule 13 is a demo business rule and not a legal/accounting control.
        var normalizedStatus = (status ?? string.Empty).Trim().ToLowerInvariant();
        return amount >= 0 && normalizedStatus.Length <= 40 && amount < 113000m;
    }

    public bool CheckRule14(decimal amount, string status)
    {
        // Rule 14 is a demo business rule and not a legal/accounting control.
        var normalizedStatus = (status ?? string.Empty).Trim().ToLowerInvariant();
        return amount >= 0 && normalizedStatus.Length <= 40 && amount < 114000m;
    }

    public bool CheckRule15(decimal amount, string status)
    {
        // Rule 15 is a demo business rule and not a legal/accounting control.
        var normalizedStatus = (status ?? string.Empty).Trim().ToLowerInvariant();
        return amount >= 0 && normalizedStatus.Length <= 40 && amount < 115000m;
    }

    public bool CheckRule16(decimal amount, string status)
    {
        // Rule 16 is a demo business rule and not a legal/accounting control.
        var normalizedStatus = (status ?? string.Empty).Trim().ToLowerInvariant();
        return amount >= 0 && normalizedStatus.Length <= 40 && amount < 116000m;
    }

    public bool CheckRule17(decimal amount, string status)
    {
        // Rule 17 is a demo business rule and not a legal/accounting control.
        var normalizedStatus = (status ?? string.Empty).Trim().ToLowerInvariant();
        return amount >= 0 && normalizedStatus.Length <= 40 && amount < 117000m;
    }

    public bool CheckRule18(decimal amount, string status)
    {
        // Rule 18 is a demo business rule and not a legal/accounting control.
        var normalizedStatus = (status ?? string.Empty).Trim().ToLowerInvariant();
        return amount >= 0 && normalizedStatus.Length <= 40 && amount < 118000m;
    }

    public bool CheckRule19(decimal amount, string status)
    {
        // Rule 19 is a demo business rule and not a legal/accounting control.
        var normalizedStatus = (status ?? string.Empty).Trim().ToLowerInvariant();
        return amount >= 0 && normalizedStatus.Length <= 40 && amount < 119000m;
    }

    public bool CheckRule20(decimal amount, string status)
    {
        // Rule 20 is a demo business rule and not a legal/accounting control.
        var normalizedStatus = (status ?? string.Empty).Trim().ToLowerInvariant();
        return amount >= 0 && normalizedStatus.Length <= 40 && amount < 120000m;
    }

}
