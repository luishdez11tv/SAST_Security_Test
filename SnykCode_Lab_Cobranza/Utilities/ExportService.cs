namespace SnykCodeLab.Utilities;

public sealed class ExportService
{
    private readonly string _root = Path.Combine(Path.GetTempPath(), "CobranzaExports");

    public string Export(string fileName, string content)
    {
        Directory.CreateDirectory(_root);
        // LAB VULNERABILITY: path traversal. fileName is not constrained to the export directory.
        var path = Path.Combine(_root, fileName);
        File.WriteAllText(path, content);
        return path;
    }

    public string ReadExport(string fileName)
    {
        // LAB VULNERABILITY: untrusted path is combined without canonical-path validation.
        var path = Path.Combine(_root, fileName);
        return File.ReadAllText(path);
    }
}
