using Bicistock.Common.Models;
using Bicistock.Data.Data.Repositories;
using System.Data;

namespace Bicistock.Domain.Services
{
    public class BikeService
    {
        //Show all bikes
        public List<Bike> MostrarTodo()
        {
            CD_Bici accesoBD = new CD_Bici();
            DataTable tabla = new DataTable();
            List<Bike> listaBicis = new List<Bike>();

            tabla = accesoBD.Mostrar();

            foreach (DataRow item in tabla.Rows)
            {
                listaBicis.Add(new Bike(item));
            }

            return listaBicis;
        }

        //Create a bike
        public void MeterBici(string name, int bikeId, string image, string description)
        {
            CD_Bici accesoBD = new CD_Bici();

            accesoBD.MeterBici(name, bikeId, image, description);
        }

        //Gets a list of bikes with its brand
        public List<Bike> BiciMarca()
        {
            CD_Bici accesoBD = new CD_Bici();
            DataTable tabla = new DataTable();
            List<Bike> listaBicis = new List<Bike>();

            tabla = accesoBD.BiciMarca();

            foreach (DataRow item in tabla.Rows)
            {
                Bike bici = new Bike();
                bici.Name = item.Field<string>(0);
                bici.BrandName = item.Field<string>(1);
                listaBicis.Add(bici);
            }

            return listaBicis;
        }
    }
}
