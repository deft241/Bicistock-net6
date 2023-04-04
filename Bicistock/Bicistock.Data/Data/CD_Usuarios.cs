using Capa_Soporte.Helpers;
using System.Data;
using System.Data.SqlClient;

namespace Bicistock.Data.Data
{
    public class CD_Usuarios
    {
        private CD_Conexion conexion = new CD_Conexion();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable MostrarUsuario(string UserName)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombreusuario", UserName);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }


        public DataTable MostrarTodos()
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarUsuarios";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        public void Insertar(string username, string password, string Dni, string name, string surnames, int age,
            string phone, string verified, byte idPermission)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsetarUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Username", username);
            comando.Parameters.AddWithValue("@Password", Encrypt.GetSHA256(password));
            comando.Parameters.AddWithValue("@DNI", Dni);
            comando.Parameters.AddWithValue("@Name", name);
            comando.Parameters.AddWithValue("@Surnames", surnames);
            comando.Parameters.AddWithValue("@Age", age);
            comando.Parameters.AddWithValue("@Phone", phone);
            comando.Parameters.AddWithValue("@Verified", verified);
            comando.Parameters.AddWithValue("@Id_Permission", idPermission);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void Eliminar(string username)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Username", username);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void ActivateUser(string username)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "UpdateUserVerificationStatus";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Username", username);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public string GetVerified(string username)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "GetVerified";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Username", username);
            leer = comando.ExecuteReader();
            conexion.CerrarConexion();
            return leer.ToString();
        }
    }
}
