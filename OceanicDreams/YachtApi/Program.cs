
using Microsoft.EntityFrameworkCore;
using YachtApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Controller támogatás
builder.Services.AddControllers();

// OpenAPI
builder.Services.AddOpenApi();

// SQLite adatbázis
builder.Services.AddDbContext<YachtDbContext>(options =>
    options.UseSqlite("Data Source=yachts.db"));

// CORS a későbbi frontendhez
builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Adatbázis létrehozása, ha még nem létezik
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider
        .GetRequiredService<YachtDbContext>();

    db.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("Frontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
