using System.Data;
using System.Data.SqlClient;

namespace Bicistock.Data.Data
{
    public class CD_Bici
    {
        CD_Conexion conexion = new CD_Conexion();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "bicisprocedure";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public void MeterBici(string name, decimal precio, int id_brand, string Image)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "meterbicis";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@name", name);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@brand", id_brand);
            comando.Parameters.AddWithValue("@Image", Image);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public DataTable BiciMarca()
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "BiciMarca";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }


    }
}
