using Bicistock.Common.Models;
using Bicistock.Data.Data.Repositories;
using System.Data;

namespace Bicistock.Domain.Services
{
    public class ComponentService
    {

        public List<Component> MostrarComponente()
        {
            ComponentRepository accesoBD = new ComponentRepository();
            List<Component> CitationList = new List<Component>();
            DataTable datos = new DataTable();

            datos = accesoBD.MostrarComponentes();
            foreach (DataRow item in datos.Rows)
            {
                CitationList.Add(new Component(item));
            }
            return CitationList;
        }

        public List<Component> ShowBrandComponent(int brandId)
        {
            ComponentRepository accesoBD = new ComponentRepository();
            List<Component> CitationList = new List<Component>();
            DataTable datos = new DataTable();

            datos = accesoBD.ShowBrandComponent(brandId);
            foreach (DataRow item in datos.Rows)
            {
                CitationList.Add(new Component(item));
            }
            return CitationList;
        }

        public void InsertarComponente(string nombreComponente, int idComponente, string rutaImagen, string desciption)
        {
            ComponentRepository accesoBD = new ComponentRepository();


            accesoBD.InsertarComponente(nombreComponente, idComponente, rutaImagen, desciption);
        }

    }
}
