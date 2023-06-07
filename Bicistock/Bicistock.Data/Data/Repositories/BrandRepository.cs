using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using Bicistock.Data.Data.DbContext;

namespace Bicistock.Data.Data.Repositories
{
    public class BrandRepository
    {
        private ConnectionManager conexion = new ConnectionManager();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        //Gets all brand
        public DataTable Marcas()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "GetBrands";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        //Gets a brand by id
        public DataTable GetBrandById(int idBrand)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "GetBrandById";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idBrand", idBrand);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
    }
}
