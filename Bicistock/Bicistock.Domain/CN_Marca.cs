using Bicistock.Common.Models;
using Bicistock.Data.Data;
using System.Data;

namespace Bicistock.Domain
{
    public class CN_Marca
    {
        public List<CS_Marca> MostrarMarcas()
        {
            CD_Marca accesoBD = new CD_Marca();

            DataTable tabla = new DataTable();

            List<CS_Marca> listMarca = new List<CS_Marca>();

            tabla = accesoBD.Marcas();

            foreach (DataRow item in tabla.Rows)
            {
                listMarca.Add(new CS_Marca(item));
            }

            return listMarca;
        }



    }
}
