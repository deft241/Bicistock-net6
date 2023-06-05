using System.Data;
using System.Data.SqlClient;
using Bicistock.Data.Data.DbContext;

namespace Bicistock.Data.Data.Repositories
{
    public class AppointmentRepository
    {
        private ConnectionManager conexion = new ConnectionManager();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        DataRow dr;


        public DataTable MostrarCitas()
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "GetAppointments";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        public void Insertar(DateTime solicitud, DateTime actual, string nombreUsu, string estadoCita, int id_brand, string description)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "NewAppointment";
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
            comando.CommandText = "DeleteAppointment";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idCita", idCita);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public DataTable GetCitationId(string username)
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "GetCitationId";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@inputName", username);
            leer = comando.ExecuteReader();
            conexion.CerrarConexion();
            tabla.Load(leer);
            return tabla;

        }
        public DataTable GetCitationById(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "GetCitationById";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", id);
            leer = comando.ExecuteReader();
            conexion.CerrarConexion();
            tabla.Load(leer);
            return tabla;
        }
    }
}
