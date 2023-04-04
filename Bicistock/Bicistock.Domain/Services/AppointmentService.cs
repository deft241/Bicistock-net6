using Bicistock.Common.Models;
using Bicistock.Data.Data;
using Bicistock.Data.Data.Repositories;
using System.Data;

namespace Bicistock.Domain.Services
{
    public class AppointmentService
    {

        public List<Appointment> MostrarCitas()
        {
            AppointmentRepository accesoBD = new AppointmentRepository();
            List<Appointment> CitationList = new List<Appointment>();
            DataTable datos = new DataTable();

            datos = accesoBD.MostrarCitas();
            foreach (DataRow item in datos.Rows)
            {
                CitationList.Add(new Appointment(item));
            }
            return CitationList;
        }

        public void NuevaCita(DateTime solicitud, DateTime actual, string nombreUsu, string estadoCita, int id_brand, string description)
        {
            AppointmentRepository accesoBD = new AppointmentRepository();


            accesoBD.Insertar(solicitud, actual, nombreUsu, estadoCita, id_brand, description);
        }

        public void Eliminar(int idCita)
        {
            AppointmentRepository accesoBD = new AppointmentRepository();

            accesoBD.Eliminar(idCita);
        }

    }
}
