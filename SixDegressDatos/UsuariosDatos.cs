using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SixDegreesEntidades;

namespace SixDegressDatos
{
    public class UsuariosDatos
    {
        private readonly string connectionString;

        public UsuariosDatos(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("Connection");
        }

        public async Task<List<Usuarios>> Get()
        {
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.UsuariosSP", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@usuID", 2));
                    cmd.Parameters.Add(new SqlParameter("@nombre", "prueba"));
                    cmd.Parameters.Add(new SqlParameter("@apellido", "prueba"));

                    Usuarios response = null;
                    List<Usuarios> lista = new List<Usuarios>();

                    await sql.OpenAsync();

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToValue(reader);
                            lista.Add(response);

                        }
                    }

                    return lista;
                }
            }
        }
        private Usuarios MapToValue(SqlDataReader reader)
        {
            return new Usuarios
            {
                usuId = (int)reader["usuID"],
                nombre = reader["nombre"].ToString(),
                apellido = reader["apellido"].ToString()
            };
        }
    }
}
