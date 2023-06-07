using Bicistock.Common.Models;
using Bicistock.Data.Data;
using Bicistock.Data.Data.Repositories;
using System.Data;

namespace Bicistock.Domain.Services
{
    public class EventService
    {
        //Show all events
        public List<Event> MostrarEventos()
        {
            EventRepository accesoBD = new EventRepository();
            List<Event> CitationList = new List<Event>();
            DataTable datos = new DataTable();

            datos = accesoBD.MostrarEvento();
            foreach (DataRow item in datos.Rows)
            {
                CitationList.Add(new Event(item));
            }
            return CitationList;
        }

        //Insert new event
        public void InsertarEvento(int brand, string description, string url)
        {
            EventRepository accesoBD = new EventRepository();

            accesoBD.InsertarEvento(brand, description, url);
        }

    }
}
