using Bicistock.Common.Models;
using Bicistock.Data.Data;
using System.Data;

namespace Bicistock.Domain
{
    public class CN_Cita
    {

        public List<CS_Cita> MostrarCitas()
        {
            CD_Cita accesoBD = new CD_Cita();
            List<CS_Cita> CitationList = new List<CS_Cita>();
            DataTable datos = new DataTable();

            datos = accesoBD.MostrarCitas();
            foreach (DataRow item in datos.Rows)
            {
                CitationList.Add(new CS_Cita(item));
            }
            return CitationList;
        }

        public void NuevaCita(DateTime solicitud, DateTime actual, string nombreUsu, string estadoCita, int id_brand, string description)
        {
            CD_Cita accesoBD = new CD_Cita();


            accesoBD.Insertar(solicitud, actual, nombreUsu, estadoCita, id_brand, description);
        }

        public void Eliminar(int idCita)
        {
            CD_Cita accesoBD = new CD_Cita();

            accesoBD.Eliminar(idCita);
        }

    }
}
