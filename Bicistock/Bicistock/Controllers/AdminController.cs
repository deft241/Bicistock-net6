using Microsoft.AspNetCore.Mvc;
using System.Data;
using Bicistock.Common.Models;
using Bicistock.Domain;

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
                CN_Usuario UserEntity = new CN_Usuario();
                CS_ModeloGeneral modeloGeneral = new CS_ModeloGeneral();
                CS_ModeloAdminPanel objAdminPanel = new CS_ModeloAdminPanel();
                objAdminPanel.UserList = UserEntity.MostrarUsuarios();

                return View(objAdminPanel);
            }

            return RedirectToAction("Index", "Home");
        }


        public IActionResult Citas()
        {
            CN_Cita conexionCita = new CN_Cita();
            CS_ModeloCita objModeloCita = new CS_ModeloCita();
            CN_Marca conexionMarca = new CN_Marca();
            List<CS_Marca> marcas = new List<CS_Marca>();

            objModeloCita.CitationList = conexionCita.MostrarCitas();

            return View(objModeloCita);
        }

        public IActionResult BorrarCita(int idCita)
        {
            CN_Cita conexionCita = new CN_Cita();
            CS_Cita objCita = new CS_Cita();

            conexionCita.Eliminar(idCita);


            return RedirectToAction("Citas");
        }



        public IActionResult AñadirComponente()
        {
            CN_Marca conexionMarca = new CN_Marca();
            CS_Marca Brand = new CS_Marca();
            CS_ModeloAdminPanel objModeloAdminPanel = new CS_ModeloAdminPanel();

            objModeloAdminPanel.BrandList = conexionMarca.MostrarMarcas();


            return View(objModeloAdminPanel);
        }


        [HttpPost]
        public IActionResult AñadirComponente(CS_ModeloAdminPanel nuevoComponente)
        {
            Logger.Logger logger = new Logger.Logger();
            CN_Componente conexionComponente = new CN_Componente();
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
            CN_Marca conexionMarca = new CN_Marca();
            CS_Marca Brand = new CS_Marca();
            CS_ModeloGeneral objModelogeneral = new CS_ModeloGeneral();

            objModelogeneral.BrandList = conexionMarca.MostrarMarcas();



            return View(objModelogeneral);


        }

        [HttpPost]
        public ActionResult AdminBikes(CS_ModeloGeneral nuevaBici)
        {
            Logger.Logger logger = new Logger.Logger();
            CN_Bici conexionBici = new CN_Bici();
            string Name = nuevaBici.BikeEntity.Name;
            string Image;
            decimal precio = nuevaBici.BikeEntity.Price;
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

                conexionBici.MeterBici(Name, precio, BrandId, Image);
                logger.Info("Se ha creado la bicicleta " + Name);
                return RedirectToAction("AdminBikes");
            }

        }





        public IActionResult AñadirEvento()
        {


            CN_Marca conexionMarca = new CN_Marca();
            CS_Marca Brand = new CS_Marca();
            CS_ModeloAdminPanel objModeloAdmin = new CS_ModeloAdminPanel();

            objModeloAdmin.BrandList = conexionMarca.MostrarMarcas();


            return View(objModeloAdmin);
        }


        [HttpPost]
        public IActionResult AñadirEvento(CS_ModeloAdminPanel nuevoEvento)
        {
            Logger.Logger logger = new Logger.Logger();
            CN_Evento conexionEvento = new CN_Evento();
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

            CN_Bici conexionBici = new CN_Bici();
            CN_Componente conexionComponente = new CN_Componente();

            CS_ModeloGeneral objModeloGeneral = new CS_ModeloGeneral();

            objModeloGeneral.BikeList = conexionBici.BiciMarca();
            objModeloGeneral.ComponentList = conexionComponente.MostrarComponente();


            return View(objModeloGeneral);
        }

        public IActionResult Eventos()
        {
            CN_Evento conexionCita = new CN_Evento();
            CS_ModeloGeneral objModeloGeneral = new CS_ModeloGeneral();

            objModeloGeneral.EventList = conexionCita.MostrarEventos();

            return View(objModeloGeneral);
        }

    }
}