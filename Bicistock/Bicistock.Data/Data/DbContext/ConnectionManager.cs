using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace Bicistock.Data.Data.DbContext
{
    public class ConnectionManager
    {
        private SqlConnection CD_conexion;
        private bool isconected = false;
        public SqlConnection AbrirConexion()
        {
            if (!isconected)
            {
                ConexionDB();
                isconected = true;
            }

            if (CD_conexion.State == ConnectionState.Closed)
                CD_conexion.Open();
            return CD_conexion;
        }

        public SqlConnection CerrarConexion()
        {
            ConexionDB();
            if (CD_conexion.State == ConnectionState.Open)
                CD_conexion.Close();
            return CD_conexion;

        }

        public void ConexionDB()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var DBconection = builder.Build().GetSection("ConnectionStrings").GetSection("aaron").Value;

            CD_conexion = new SqlConnection(DBconection);
        }

    }
}
