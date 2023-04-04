using Bicistock.Common.Models;
using Bicistock.Data.Data;
using System.Data;

namespace Bicistock.Domain
{
    public class CN_Componente
    {

        public List<CS_Componente> MostrarComponente()
        {
            CD_Componente accesoBD = new CD_Componente();
            List<CS_Componente> CitationList = new List<CS_Componente>();
            DataTable datos = new DataTable();

            datos = accesoBD.MostrarComponentes();
            foreach (DataRow item in datos.Rows)
            {
                CitationList.Add(new CS_Componente(item));
            }
            return CitationList;
        }

        public void InsertarComponente(string nombreComponente, int idComponente, string rutaImagen)
        {
            CD_Componente accesoBD = new CD_Componente();


            accesoBD.InsertarComponente(nombreComponente, idComponente, rutaImagen);
        }

    }
}
