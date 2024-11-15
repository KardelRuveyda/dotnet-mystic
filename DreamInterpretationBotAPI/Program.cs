using DreamInterpretationBotAPI.Models.Constants;
using DreamInterpretationBotAPI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// appsettings.json ve secrets.json dosyalarını yükleme
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // appsettings.json'ı yükler
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true) // Ortam spesifik ayarları yükler
    .AddUserSecrets<Program>(optional: true, reloadOnChange: true); // Geliştirme ortamında secrets.json'ı yükler

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

// OpenAIConstants ayarlarını configure etme
builder.Services.AddOptions<OpenAIConstants>()
    .Bind(builder.Configuration.GetSection("OpenAIConstants")) // OpenAIConstants sekmesinden bağlama
    .ValidateDataAnnotations() // Veri doğrulaması yapma
    .Validate(settings => !string.IsNullOrEmpty(settings.ApiKey) && !string.IsNullOrEmpty(settings.FilePath), 
              "Configuration settings are missing or incomplete. Please check appsettings.json or secrets.json.")
    .Configure(options => 
    {
        // Loglama veya debug işlemleri yapılabilir
        Console.WriteLine($"ApiKey: {options.ApiKey}, FilePath: {options.FilePath}");
    });

#endregion

// Hizmetlerin eklenmesi
builder.Services.AddScoped<IDreamInterpretationService, DreamInterpretationService>(); // Servis ekleme

// Controller'ları ekleyin
builder.Services.AddControllers();

// Swagger ekleme
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// CORS politikasını kullan
app.UseCors("AllowBlazorFrontend");

// Swagger konfigürasyonu
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Authorization kullanmıyorsanız bu satırı kaldırabilirsiniz
// app.UseAuthorization();

app.MapControllers(); // Controller'ların çalışabilmesi için gerekli

app.Run();
