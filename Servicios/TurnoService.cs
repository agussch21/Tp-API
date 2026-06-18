using Microsoft.Data.Sqlite;
using TurnosMedicosAPI.DTOs;

namespace TurnosMedicosAPI.Services
{
    public class TurnoService
    {
        private readonly string _connection;

        public TurnoService(string connection)
        {
            _connection = connection;
        }

        public async Task<List<TurnoDTO>> ObtenerTodos()
        {
            var lista = new List<TurnoDTO>();
            using var cn = new SqliteConnection(_connection);
            await cn.OpenAsync();
            
            using var cmd = cn.CreateCommand();
            cmd.CommandText = @"
                SELECT t.Id, t.FechaHora, t.Especialidad, t.PacienteId, p.NombreCompleto 
                FROM Turnos t
                INNER JOIN Pacientes p ON t.PacienteId = p.Id;";
            
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                lista.Add(new TurnoDTO
                {
                    Id = reader.GetInt32(0),
                    FechaHora = DateTime.Parse(reader.GetString(1)),
                    Especialidad = reader.GetString(2),
                    PacienteId = reader.GetInt32(3),
                    NombrePaciente = reader.GetString(4)
                });
            }
            return lista;
        }

        public async Task Crear(TurnoDTO dto)
        {
            using var cn = new SqliteConnection(_connection);
            await cn.OpenAsync();
            
            using var cmd = cn.CreateCommand();
            cmd.CommandText = "INSERT INTO Turnos (FechaHora, Especialidad, PacienteId) VALUES ($fecha, $especialidad, $pacienteId);";
            cmd.Parameters.AddWithValue("$fecha", dto.FechaHora.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("$especialidad", dto.Especialidad);
            cmd.Parameters.AddWithValue("$pacienteId", dto.PacienteId);
            
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task Actualizar(int id, TurnoDTO dto)
        {
            using var cn = new SqliteConnection(_connection);
            await cn.OpenAsync();
            
            using var cmd = cn.CreateCommand();
            cmd.CommandText = "UPDATE Turnos SET FechaHora = $fecha, Especialidad = $especialidad, PacienteId = $pacienteId WHERE Id = $id;";
            cmd.Parameters.AddWithValue("$fecha", dto.FechaHora.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("$especialidad", dto.Especialidad);
            cmd.Parameters.AddWithValue("$pacienteId", dto.PacienteId);
            cmd.Parameters.AddWithValue("$id", id);
            
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task Eliminar(int id)
        {
            using var cn = new SqliteConnection(_connection);
            await cn.OpenAsync();
            
            using var cmd = cn.CreateCommand();
            cmd.CommandText = "DELETE FROM Turnos WHERE Id = $id;";
            cmd.Parameters.AddWithValue("$id", id);
            
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
