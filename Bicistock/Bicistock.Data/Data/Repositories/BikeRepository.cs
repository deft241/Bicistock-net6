using Bicistock.Data.Data.DbContext;
using System.Data;
using System.Data.SqlClient;

namespace Bicistock.Data.Data.Repositories
{
    public class CD_Bici
    {
        ConnectionManager conexion = new ConnectionManager();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        //Show a bike
        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SelectAllBikes";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        //Create a bike 
        public void MeterBici(string name, int brandId, string image, string description)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "NewBike";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@name", name);
            comando.Parameters.AddWithValue("@brand", brandId);
            comando.Parameters.AddWithValue("@bike_image", image);
            comando.Parameters.AddWithValue("@description", description);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
        //Gets a list of bikes with its brand

        public DataTable BiciMarca()
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "BikeByBrand";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }


    }
}
