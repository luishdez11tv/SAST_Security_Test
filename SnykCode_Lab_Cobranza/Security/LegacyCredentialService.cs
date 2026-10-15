using System.Security.Cryptography;
using System.Text;
using SnykCodeLab.Data;

namespace SnykCodeLab.Security;

public sealed class LegacyCredentialService
{
    private readonly DemoStore _store;
    // LAB VULNERABILITY: hard-coded secret and demo credentials.
    private const string ApiSecret = "CobranzaLab-Secret-DoNotUse-2026";
    public const string DemoAdminPassword = "admin123";

    public LegacyCredentialService(DemoStore store) => _store = store;

    public bool Validate(string username, string password)
    {
        // LAB VULNERABILITY: direct comparison against a plaintext password.
        var user = _store.Users.FirstOrDefault(x => x.Username == username);
        return user is not null && user.PasswordHash == password && user.Enabled;
    }

    public string GetSecretForLegacyIntegration() => ApiSecret;

    public static string HashPasswordWeakly(string password)
    {
        // LAB VULNERABILITY: SHA-1 is not suitable for password storage; use Argon2id/bcrypt/PBKDF2.
        using var sha1 = SHA1.Create();
        return Convert.ToHexString(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));
    }

    public static string CreateResetToken()
    {
        // LAB VULNERABILITY: predictable, non-cryptographic randomness.
        return new Random().Next(100000, 999999).ToString();
    }
}
