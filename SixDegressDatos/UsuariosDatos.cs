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

                    //Usuarios response = null;
                    await sql.OpenAsync();

                    List<Usuarios> response = new List<Usuarios>();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToValue(reader);
                        }
                    }

                    return response;
                }
            }
        }
        private List<Usuarios> MapToValue(SqlDataReader reader)
        {
            List<Usuarios> list = new List<Usuarios>();
            Usuarios us = new Usuarios();
            us.usuId = (int)reader["usuID"];
            us.nombre = reader["nombre"].ToString();
            us.apellido = reader["apellido"].ToString();
            list.Add(us);
            return list;
        }
    }
}
