using GestioVisites.Domain.Entities;
using GestioVisites.Domain.Interfaces;
using Microsoft.Data.SqlClient;

namespace GestioVisites.Infraestructure.Repositories
{
    public class VisitaMedicaRepository : IVisitaMedicaRepository
    {
        private readonly string _connectionString = "Server=localhost;Database=bd_accesDades;Trusted_Connection=True; Encrypt=False;";

        public void Create(VisitaMedica visita)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO VisitaMedica (NomPacient, NomMetge, DataVisita, Diagnostic) VALUES (@NomPacient, @NomMetge, @DataVisita, @Diagnostic)";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NomPacient", visita.NomPacient);
                        command.Parameters.AddWithValue("@NomMetge", visita.NomMetge);
                        command.Parameters.AddWithValue("@DataVisita", visita.DataVisita);
                        command.Parameters.AddWithValue("@Diagnostic", visita.Diagnostic ?? (object)DBNull.Value);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al conectar o guardar en la base de dades: " + ex.Message);
            }
        }

        public IEnumerable<VisitaMedica> GetAll()
        {
            var visites = new List<VisitaMedica>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT PK_VisitaMedicaID, NomPacient, NomMetge, DataVisita, Diagnostic FROM VisitaMedica";
                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                visites.Add(new VisitaMedica
                                {
                                    PK_VisitaMedicaID = reader.GetInt32(0),
                                    NomPacient = reader.GetString(1),
                                    NomMetge = reader.GetString(2),
                                    DataVisita = reader.GetDateTime(3),
                                    Diagnostic = reader.IsDBNull(4) ? null : reader.GetString(4)
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al llegir la base de dades: " + ex.Message);
            }

            return visites;
        }

        public VisitaMedica? GetById(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT PK_VisitaMedicaID, NomPacient, NomMetge, DataVisita, Diagnostic FROM VisitaMedica WHERE PK_VisitaMedicaID = @Id";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new VisitaMedica
                                {
                                    PK_VisitaMedicaID = reader.GetInt32(0),
                                    NomPacient = reader.GetString(1),
                                    NomMetge = reader.GetString(2),
                                    DataVisita = reader.GetDateTime(3),
                                    Diagnostic = reader.IsDBNull(4) ? null : reader.GetString(4)
                                };
                            }
                        }
                    }
                }
                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al buscar el registre en la base de dades: " + ex.Message);
            }
        }
        public void Update(VisitaMedica visita)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "UPDATE VisitaMedica SET NomPacient = @NomPacient, NomMetge = @NomMetge, DataVisita = @DataVisita, Diagnostic = @Diagnostic WHERE PK_VisitaMedicaID = @Id";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", visita.PK_VisitaMedicaID);
                        command.Parameters.AddWithValue("@NomPacient", visita.NomPacient);
                        command.Parameters.AddWithValue("@NomMetge", visita.NomMetge);
                        command.Parameters.AddWithValue("@DataVisita", visita.DataVisita);
                        command.Parameters.AddWithValue("@Diagnostic", visita.Diagnostic ?? (object)DBNull.Value);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al actualizar la base de dades: " + ex.Message);
            }
        }
        public void Delete(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM VisitaMedica WHERE PK_VisitaMedicaID = @Id";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al eliminar en la base de dades: " + ex.Message);
            }
        }
    }
}