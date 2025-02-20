var builder = WebApplication.CreateBuilder();

var app = builder.Build();

app.MapGet("/", () => "Server running");

app.MapPost("/upload", () => "");

app.Run();

public partial class Program { }