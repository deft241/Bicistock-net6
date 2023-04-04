using Microsoft.AspNetCore.Mvc;
using System.Data;
using Bicistock.Common.Models;
using Bicistock.Domain;
using Bicistock.Domain.Services;

namespace Bicistock.Controllers
{
    public class AdminController : Controller
    {
        private IWebHostEnvironment Environment;

        public AdminController(IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Panel");
        }
        public IActionResult Panel()
        {

            if (HttpContext.Session.GetInt32("Role") == 2)
            {
                UserService UserEntity = new UserService();
                InventoryManager modeloGeneral = new InventoryManager();
                AdminPanelData objAdminPanel = new AdminPanelData();
                objAdminPanel.UserList = UserEntity.MostrarUsuarios();

                return View(objAdminPanel);
            }

            return RedirectToAction("Index", "Home");
        }


        public IActionResult Citas()
        {
            AppointmentService conexionCita = new AppointmentService();
            AppointmentManager objModeloCita = new AppointmentManager();
            BrandService conexionMarca = new BrandService();
            List<Brand> marcas = new List<Brand>();

            objModeloCita.CitationList = conexionCita.MostrarCitas();

            return View(objModeloCita);
        }

        public IActionResult BorrarCita(int idCita)
        {
            AppointmentService conexionCita = new AppointmentService();
            Appointment objCita = new Appointment();

            conexionCita.Eliminar(idCita);


            return RedirectToAction("Citas");
        }



        public IActionResult AñadirComponente()
        {
            BrandService conexionMarca = new BrandService();
            Brand Brand = new Brand();
            AdminPanelData objModeloAdminPanel = new AdminPanelData();

            objModeloAdminPanel.BrandList = conexionMarca.MostrarMarcas();


            return View(objModeloAdminPanel);
        }


        [HttpPost]
        public IActionResult AñadirComponente(AdminPanelData nuevoComponente)
        {
            Logger.Logger logger = new Logger.Logger();
            ComponentService conexionComponente = new ComponentService();
            string Name = nuevoComponente.Component.Name;
            string componenteImagen;

            int BrandId = nuevoComponente.Brand.Id;

            //Meter foto carpeta imagenes
            string wwwPath = Environment.WebRootPath;
            string contentPath = Environment.ContentRootPath;



            string path = Path.Combine(Environment.WebRootPath, "Images");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            List<string> uploadedFiles = new List<string>();


            string fileName = Path.GetFileName(nuevoComponente.Component.Component_Image_Upload.FileName);
            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {

                nuevoComponente.Component.Component_Image_Upload.CopyTo(stream);
                uploadedFiles.Add(fileName);
                componenteImagen = "/Images/" + fileName;
                ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);

                logger.Info("Se ha creado el Componente " + Name);
                conexionComponente.InsertarComponente(Name, BrandId, componenteImagen);
                return RedirectToAction("AñadirComponente");
            }

        }

        public ActionResult AdminBikes()
        {
            BrandService conexionMarca = new BrandService();
            Brand Brand = new Brand();
            InventoryManager objModelogeneral = new InventoryManager();

            objModelogeneral.BrandList = conexionMarca.MostrarMarcas();



            return View(objModelogeneral);


        }

        [HttpPost]
        public ActionResult AdminBikes(InventoryManager nuevaBici)
        {
            Logger.Logger logger = new Logger.Logger();
            BikeService conexionBici = new BikeService();
            string Name = nuevaBici.BikeEntity.Name;
            string Image;
            int BrandId = nuevaBici.Brand.Id;

            //Meter foto carpeta imagenes
            string wwwPath = Environment.WebRootPath;
            string contentPath = Environment.ContentRootPath;



            string path = Path.Combine(Environment.WebRootPath, "Images");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            List<string> uploadedFiles = new List<string>();


            string fileName = Path.GetFileName(nuevaBici.BikeEntity.Image_upload.FileName);
            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {

                nuevaBici.BikeEntity.Image_upload.CopyTo(stream);
                uploadedFiles.Add(fileName);
                Image = "/Images/" + fileName;
                ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);

                conexionBici.MeterBici(Name, BrandId, Image);
                logger.Info("Se ha creado la bicicleta " + Name);
                return RedirectToAction("AdminBikes");
            }

        }





        public IActionResult AñadirEvento()
        {


            BrandService conexionMarca = new BrandService();
            Brand Brand = new Brand();
            AdminPanelData objModeloAdmin = new AdminPanelData();

            objModeloAdmin.BrandList = conexionMarca.MostrarMarcas();


            return View(objModeloAdmin);
        }


        [HttpPost]
        public IActionResult AñadirEvento(AdminPanelData nuevoEvento)
        {
            Logger.Logger logger = new Logger.Logger();
            EventService conexionEvento = new EventService();
            string desc = nuevoEvento.Event.EventDescription;
            string eventoImagen;

            int BrandId = nuevoEvento.Brand.Id;

            //Meter foto carpeta imagenes
            string wwwPath = Environment.WebRootPath;
            string contentPath = Environment.ContentRootPath;



            string path = Path.Combine(Environment.WebRootPath, "Images");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            List<string> uploadedFiles = new List<string>();


            string fileName = Path.GetFileName(nuevoEvento.Event.Event_Image_upload.FileName);
            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {

                nuevoEvento.Event.Event_Image_upload.CopyTo(stream);
                uploadedFiles.Add(fileName);
                eventoImagen = "/Images/" + fileName;
                ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);

                conexionEvento.InsertarEvento(desc, eventoImagen, BrandId);
                logger.Info("Se ha creado un nuevo Event");
                return RedirectToAction("AñadirEvento");
            }

        }

        public IActionResult Productos()
        {

            BikeService conexionBici = new BikeService();
            ComponentService conexionComponente = new ComponentService();

            InventoryManager objModeloGeneral = new InventoryManager();

            objModeloGeneral.BikeList = conexionBici.BiciMarca();
            objModeloGeneral.ComponentList = conexionComponente.MostrarComponente();


            return View(objModeloGeneral);
        }

        public IActionResult Eventos()
        {
            EventService conexionCita = new EventService();
            InventoryManager objModeloGeneral = new InventoryManager();

            objModeloGeneral.EventList = conexionCita.MostrarEventos();

            return View(objModeloGeneral);
        }

    }
}