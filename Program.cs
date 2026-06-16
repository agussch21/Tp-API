using Microsoft.EntityFrameworkCore;
using TurnosMedicosAPI.Data;
using TurnosMedicosAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=turnos.db"));

builder.Services.AddScoped<PacienteService>();
builder.Services.AddScoped<TurnoService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
