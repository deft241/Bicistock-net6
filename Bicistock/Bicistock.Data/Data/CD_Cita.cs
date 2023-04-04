using System.Data;
using System.Data.SqlClient;

namespace Bicistock.Data.Data
{
    public class CD_Cita
    {
        private CD_Conexion conexion = new CD_Conexion();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();


        public DataTable MostrarCitas()
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SacaCitas";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        public void Insertar(DateTime solicitud, DateTime actual, string nombreUsu, string estadoCita, int id_brand, string description)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarCita";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Datecitation", solicitud);
            comando.Parameters.AddWithValue("@Daterequest", actual);
            comando.Parameters.AddWithValue("@Username", nombreUsu);
            comando.Parameters.AddWithValue("@Status", estadoCita);
            comando.Parameters.AddWithValue("@Idbrand", id_brand);
            comando.Parameters.AddWithValue("@Description", description);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void Eliminar(int idCita)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "BorrarCita";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idCita", idCita);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}
