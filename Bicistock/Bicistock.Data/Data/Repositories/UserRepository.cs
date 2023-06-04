using Bicistock.Common.Models;
using Bicistock.Data.Data.DbContext;
using Capa_Soporte.Helpers;
using System.Data;
using System.Data.SqlClient;

namespace Bicistock.Data.Data.Repositories
{
    public class UserRepository
    {
        private ConnectionManager conexion = new ConnectionManager();
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
            string phone, string verified, byte idPermission, string email)
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
            comando.Parameters.AddWithValue("@Email", email);
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

        public bool UpdateUser(User newUserData)
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "UPDATE [USER] SET Dni = @Dni, [Name] = @Name, Surnames = @Surnames, Age = @Age, Phone = @Phone, Verified = @Verified, [Id_Permission] =@Role, Email = @UserEmail WHERE Username = @UserName;";
            comando.CommandType = CommandType.Text;
            comando.Parameters.AddWithValue("@UserName", newUserData.UserName);
            comando.Parameters.AddWithValue("@Dni", newUserData.Dni);
            comando.Parameters.AddWithValue("@Name", newUserData.Name);
            comando.Parameters.AddWithValue("@Surnames", newUserData.Surnames);
            comando.Parameters.AddWithValue("@Age", newUserData.Age);
            comando.Parameters.AddWithValue("@Phone", newUserData.Phone);
            comando.Parameters.AddWithValue("@Verified", newUserData.Verified);
            comando.Parameters.AddWithValue("@Role", newUserData.Role);
            comando.Parameters.AddWithValue("@UserEmail", newUserData.UserEmail);
            comando.ExecuteNonQuery();
            conexion.CerrarConexion();


            return true;
        }
    }
}
