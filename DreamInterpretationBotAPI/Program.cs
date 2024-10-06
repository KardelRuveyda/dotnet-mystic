using DreamInterpretationBotAPI.Models.Constants;
using DreamInterpretationBotAPI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// appsettings.json'� y�kleme
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddUserSecrets<Program>(optional: true, reloadOnChange: true);


// CORS ekleme
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorFrontend", policyBuilder =>
    {
        policyBuilder.WithOrigins("https://localhost:7128") // Blazor projenizin URL'si
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials();
    });
});
#region Configuration
// Configuration

builder.Services.AddOptions<OpenAIConstants>()
    .Bind(builder.Configuration.GetSection(OpenAIConstants.Key))
    .ValidateDataAnnotations()
    .Validate(settings => !string.IsNullOrEmpty(settings.ApiKey) && !string.IsNullOrEmpty(settings.FilePath),
              "Configuration settings are missing or incomplete. Please check appsettings.json.");



#endregion

builder.Services.AddScoped<IDreamInterpretationService, DreamInterpretationService>();
// Controller'lar� ekleyin
builder.Services.AddControllers();

// Swagger ekleme
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// CORS politikas�n� kullan
app.UseCors("AllowBlazorFrontend");

// Swagger konfig�rasyonu
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// E�er yetkilendirme kullanm�yorsan�z bu sat�r� kald�r�n
// app.UseAuthorization();

app.MapControllers(); // Controller'lar�n �al��abilmesi i�in gerekli

app.Run();
