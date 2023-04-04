using Bicistock.Common.Models;
using Bicistock.Data.Data;
using System.Data;

namespace Bicistock.Domain
{
    public class CN_Bici
    {
        public List<CS_Bici> MostrarTodo()
        {
            CD_Bici accesoBD = new CD_Bici();
            DataTable tabla = new DataTable();
            List<CS_Bici> listaBicis = new List<CS_Bici>();

            tabla = accesoBD.Mostrar();

            foreach (DataRow item in tabla.Rows)
            {
                listaBicis.Add(new CS_Bici(item));
            }

            return listaBicis;
        }

        public void MeterBici(string name, decimal precio, int id_brand, string Image)
        {
            CD_Bici accesoBD = new CD_Bici();

            accesoBD.MeterBici(name, precio, id_brand, Image);
        }

        public List<CS_Bici> BiciMarca()
        {
            CD_Bici accesoBD = new CD_Bici();
            DataTable tabla = new DataTable();
            List<CS_Bici> listaBicis = new List<CS_Bici>();

            tabla = accesoBD.BiciMarca();

            foreach (DataRow item in tabla.Rows)
            {
                CS_Bici bici = new CS_Bici();
                bici.Name = item.Field<string>(0);
                bici.Price = item.Field<decimal>(1);
                bici.BrandName = item.Field<string>(2);
                listaBicis.Add(bici);
            }

            return listaBicis;
        }
    }
}
