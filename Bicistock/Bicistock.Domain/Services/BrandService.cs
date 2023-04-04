using Bicistock.Common.Models;
using Bicistock.Data.Data;
using Bicistock.Data.Data.Repositories;
using System.Data;

namespace Bicistock.Domain.Services
{
    public class BrandService
    {
        public List<Brand> MostrarMarcas()
        {
            BrandRepository accesoBD = new BrandRepository();

            DataTable tabla = new DataTable();

            List<Brand> listMarca = new List<Brand>();

            tabla = accesoBD.Marcas();

            foreach (DataRow item in tabla.Rows)
            {
                listMarca.Add(new Brand(item));
            }

            return listMarca;
        }



    }
}
