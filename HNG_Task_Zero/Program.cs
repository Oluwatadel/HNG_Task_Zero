var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

var httpClient = new HttpClient()
{
    Timeout = TimeSpan.FromSeconds(30)
};

app.MapGet("/health", () => Results.Ok("Healthy"));

app.MapGet("/me", async () =>
{
    var catFact = await httpClient.GetFromJsonAsync<CatFact>("https://catfact.ninja/fact");
    var result = new
    {
        status = "success",
        user = new
        {
            email = "oluwatadel12@gmail.com",
            name = "Adelesi Oluwatobi",
            stack = "C#",
        },
        timestamp = DateTime.UtcNow.ToString("o"),
        catFact = catFact?.Fact ?? "Problem reading from cat fact API"
    };
    return Results.Ok(result);
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public class CatFact
{
    public string? Fact { get; set; } = string.Empty;
    public int Length { get; set; }
}