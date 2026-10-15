using SnykCodeLab.Data;
using SnykCodeLab.Security;
using SnykCodeLab.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSingleton<DemoStore>();
builder.Services.AddSingleton<InvoiceService>();
builder.Services.AddSingleton<CustomerService>();
builder.Services.AddSingleton<PaymentService>();
builder.Services.AddSingleton<ReportService>();
builder.Services.AddSingleton<LegacyCredentialService>();
builder.Services.AddCors(options =>
{
    // LAB VULNERABILITY: overly permissive CORS policy for demonstration.
    options.AddPolicy("OpenLabPolicy", policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
var app = builder.Build();
app.UseCors("OpenLabPolicy");
// LAB VULNERABILITY: no authentication/authorization middleware is configured.
app.MapControllers();
app.MapGet("/", () => Results.Ok(new
{
    name = "SnykCode Cobranza Lab",
    warning = "Intentionally vulnerable training application. Never deploy."
}));
app.Run();
