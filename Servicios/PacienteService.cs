using Microsoft.Data.Sqlite;
using TurnosMedicosAPI.DTOs;

namespace TurnosMedicosAPI.Services
{
    public class PacienteService
    {
        private readonly string _connection;

        public PacienteService(string connection)
        {
            _connection = connection;
        }

        public async Task<List<PacienteDTO>> ObtenerTodos()
        {
            var lista = new List<PacienteDTO>();
            using var cn = new SqliteConnection(_connection);
            await cn.OpenAsync();
            
            using var cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT Id, NombreCompleto, DNI, ObraSocial FROM Pacientes;";
            
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                lista.Add(new PacienteDTO
                {
                    Id = reader.GetInt32(0),
                    NombreCompleto = reader.GetString(1),
                    DNI = reader.GetString(2),
                    ObraSocial = reader.IsDBNull(3) ? "" : reader.GetString(3)
                });
            }
            return lista;
        }

        public async Task Crear(PacienteDTO dto)
        {
            using var cn = new SqliteConnection(_connection);
            await cn.OpenAsync();
            
            using var cmd = cn.CreateCommand();
            cmd.CommandText = "INSERT INTO Pacientes (NombreCompleto, DNI, ObraSocial) VALUES ($nombre, $dni, $obraSocial);";
            cmd.Parameters.AddWithValue("$nombre", dto.NombreCompleto);
            cmd.Parameters.AddWithValue("$dni", dto.DNI);
            cmd.Parameters.AddWithValue("$obraSocial", dto.ObraSocial ?? (object)DBNull.Value);
            
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task Actualizar(int id, PacienteDTO dto)
        {
            using var cn = new SqliteConnection(_connection);
            await cn.OpenAsync();
            
            using var cmd = cn.CreateCommand();
            cmd.CommandText = "UPDATE Pacientes SET NombreCompleto = $nombre, DNI = $dni, ObraSocial = $obraSocial WHERE Id = $id;";
            cmd.Parameters.AddWithValue("$nombre", dto.NombreCompleto);
            cmd.Parameters.AddWithValue("$dni", dto.DNI);
            cmd.Parameters.AddWithValue("$obraSocial", dto.ObraSocial ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("$id", id);
            
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task Eliminar(int id)
        {
            using var cn = new SqliteConnection(_connection);
            await cn.OpenAsync();
            
            using var cmd = cn.CreateCommand();
            cmd.CommandText = "DELETE FROM Pacientes WHERE Id = $id;";
            cmd.Parameters.AddWithValue("$id", id);
            
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
