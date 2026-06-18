using TurnosMedicosAPI.Services;
using Microsoft.Data.Sqlite;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

string cadenaConexion = "Data Source=turnos.db";

builder.Services.AddScoped(provider => new PacienteService(cadenaConexion));
builder.Services.AddScoped(provider => new TurnoService(cadenaConexion));

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

using (var cn = new SqliteConnection(cadenaConexion))
{
    cn.Open();
    using var cmd = cn.CreateCommand();
    
    cmd.CommandText = @"
        CREATE TABLE IF NOT EXISTS Pacientes (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            NombreCompleto TEXT NOT NULL,
            DNI TEXT NOT NULL,
            ObraSocial TEXT
        );";
    cmd.ExecuteNonQuery();

    cmd.CommandText = @"
        CREATE TABLE IF NOT EXISTS Turnos (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            FechaHora TEXT NOT NULL,
            Especialidad TEXT NOT NULL,
            PacienteId INTEGER NOT NULL
        );";
    cmd.ExecuteNonQuery();
}

app.Run();
