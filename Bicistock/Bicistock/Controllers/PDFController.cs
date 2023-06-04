using Bicistock.Common.Models;
using Bicistock.Controllers.Filters;
using Bicistock.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace Bicistock.Controllers
{
    [TypeFilter(typeof(AdminAuthorizationHandler))]
    public class PDFController : Controller
    {
        private IWebHostEnvironment Environment;

        public PDFController(IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }

        public IActionResult Panel()
        {
            Logger.Logger logger = new Logger.Logger();

            UserService UserEntity = new UserService();
            InventoryManager modeloGeneral = new InventoryManager();
            AdminPanelData objAdminPanel = new AdminPanelData();
            objAdminPanel.UserList = UserEntity.MostrarUsuarios();


            logger.Info("Se ha generado un PDF de la lista de usuarios existentes");
            return new ViewAsPdf("Panel", objAdminPanel);


        }

        public IActionResult Citas()
        {
            Logger.Logger logger = new Logger.Logger();

            AppointmentService conexionCita = new AppointmentService();
            AppointmentManager objModeloCita = new AppointmentManager();
            BrandService conexionMarca = new BrandService();
            List<Brand> marcas = new List<Brand>();

            objModeloCita.CitationList = conexionCita.MostrarCitas();

            logger.Info("Se ha generado un PDF de la lista citas");


            return new ViewAsPdf("Citas", objModeloCita);
        }


        public IActionResult Productos()
        {
            Logger.Logger logger = new Logger.Logger();

            BikeService conexionBici = new BikeService();
            ComponentService conexionComponente = new ComponentService();

            InventoryManager objModeloGeneral = new InventoryManager();

            objModeloGeneral.BikeList = conexionBici.BiciMarca();
            objModeloGeneral.ComponentList = conexionComponente.MostrarComponente();

            logger.Info("Se ha generado un PDF de la lista de productos");

            return new ViewAsPdf("Productos", objModeloGeneral);
        }

        public IActionResult Eventos()
        {
            Logger.Logger logger = new Logger.Logger();

            EventService eventService = new EventService();

            InventoryManager objModeloGeneral = new InventoryManager();

            objModeloGeneral.EventList = eventService.MostrarEventos();      

            logger.Info("Se ha generado un PDF de la lista de productos");

            return new ViewAsPdf("Eventos", objModeloGeneral);
        }

    }
}