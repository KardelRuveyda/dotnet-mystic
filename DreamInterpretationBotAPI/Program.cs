var builder = WebApplication.CreateBuilder(args);

// appsettings.json'ý yükleme
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

// Controller'larý ekleyin
builder.Services.AddControllers();

// Swagger ekleme
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// CORS politikasýný kullan
app.UseCors("AllowBlazorFrontend");

// Swagger konfigürasyonu
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Eðer yetkilendirme kullanmýyorsanýz bu satýrý kaldýrýn
// app.UseAuthorization();

app.MapControllers(); // Controller'larýn çalýþabilmesi için gerekli

app.Run();
