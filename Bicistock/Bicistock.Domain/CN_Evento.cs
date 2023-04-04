using Bicistock.Common.Models;
using Bicistock.Data.Data;
using System.Data;

namespace Bicistock.Domain
{
    public class CN_Evento
    {
        public List<CS_Evento> MostrarEventos()
        {
            CD_Evento accesoBD = new CD_Evento();
            List<CS_Evento> CitationList = new List<CS_Evento>();
            DataTable datos = new DataTable();

            datos = accesoBD.MostrarEvento();
            foreach (DataRow item in datos.Rows)
            {
                CitationList.Add(new CS_Evento(item));
            }
            return CitationList;
        }

        public void InsertarEvento(string descipcion, string imagen, int Brand)
        {
            CD_Evento accesoBD = new CD_Evento();

            accesoBD.InsertarEvento(descipcion, imagen, Brand);
        }

    }
}
