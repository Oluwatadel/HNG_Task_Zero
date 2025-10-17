using System.Text.Json;
using System.Text.Json.Serialization;

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
    string apiUrl = $"https://catfact.ninja/fact?rand={Guid.NewGuid()}";
    CatFact? catFact = null;
    try
    {
        catFact = await httpClient.GetFromJsonAsync<CatFact>(apiUrl);
    }
    catch
    {
        catFact = new CatFact 
        { 
            Fact = "Could not fetch cat fact at the moment. Please try again later."
        };
    }
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
        fact = catFact?.Fact
    };
    return Results.Json(result, new System.Text.Json.JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    });
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public class CatFact
{
    [JsonPropertyName("fact")]
    public string? Fact { get; set; } = string.Empty;

    [JsonPropertyName("length")]
    public int Length { get; set; }
}