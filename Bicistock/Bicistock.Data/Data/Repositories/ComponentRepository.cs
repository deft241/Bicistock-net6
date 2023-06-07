using System.Data;
using System.Data.SqlClient;
using Bicistock.Data.Data.DbContext;

namespace Bicistock.Data.Data.Repositories
{
    public class ComponentRepository
    {
        private ConnectionManager conexion = new ConnectionManager();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        //Shows all components
        public DataTable MostrarComponentes()
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SelectAllComponents";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        //Gets the brand of a component
        public DataTable ShowBrandComponent(int brandId)
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SelectBrandComponent";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@brandId", brandId);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        //Create a new one
        public void InsertarComponente(string nombreComponente, int idComponente, string rutaImagen, string description)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "NewComponent";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombreComponente", nombreComponente);
            comando.Parameters.AddWithValue("@idmarca", idComponente);
            comando.Parameters.AddWithValue("@rutaImagen", rutaImagen);
            comando.Parameters.AddWithValue("@description", rutaImagen);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }


    }
}
