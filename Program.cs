using Microsoft.EntityFrameworkCore;
using TurnosMedicosAPI.Data;
using TurnosMedicosAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=turnos.db"));

builder.Services.AddScoped<PacienteService>();
builder.Services.AddScoped<TurnoService>();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

using (var scope = app.Services.createScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
    }

app.Run();
