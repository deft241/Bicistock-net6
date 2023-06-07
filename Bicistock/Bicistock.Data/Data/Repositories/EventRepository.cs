using System.Data;
using System.Data.SqlClient;
using Bicistock.Data.Data.DbContext;

namespace Bicistock.Data.Data.Repositories
{
    public class EventRepository
    {
        private ConnectionManager conexion = new ConnectionManager();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        //Shows event
        public DataTable MostrarEvento()
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ShowEvents";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        //Create a new one
        public void InsertarEvento(int brand, string description, string url)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "NewEvent";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Brand", brand);
            comando.Parameters.AddWithValue("@Description", description);
            comando.Parameters.AddWithValue("@Url", url);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}
