using System.Data;
using System.Data.SqlClient;

namespace Bicistock.Data.Data
{
    public class CD_Marca
    {
        private CD_Conexion conexion = new CD_Conexion();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();


        public DataTable Marcas()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sacarmarcas";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
    }
}
