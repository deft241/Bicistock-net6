using Bicistock.Common.Models;
using Bicistock.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bicistock.Controllers
{
    public class BikesController : Controller
    {
        public IActionResult Index()
        {
            BrandService conexionMarca = new BrandService();
            Brand Brand = new Brand();




            InventoryManager modeloGeneral = new InventoryManager();
            List<Bike> listabicis = new List<Bike>();
            BikeService conexionBici = new BikeService();
            string placeholder = "/Images/placeholder.jpg";

            modeloGeneral.BikeList = conexionBici.MostrarTodo();

            foreach (var item in modeloGeneral.BikeList)
            {
                if (string.IsNullOrEmpty(item.Image))
                {
                    item.Image = placeholder;
                }
            }

            modeloGeneral.BrandList = conexionMarca.MostrarMarcas();

            return View(modeloGeneral);
        }


        [HttpPost]
        public IActionResult Index(InventoryManager filtrar)
        {
            BrandService conexionMarca = new BrandService();
            Brand Brand = new Brand();

            InventoryManager modeloGeneral = new InventoryManager();
            List<Bike> listabicis = new List<Bike>();
            BikeService conexionBici = new BikeService();
            string placeholder = "/Images/placeholder.jpg";
            modeloGeneral.Brand = new Brand();

            modeloGeneral.BikeList = conexionBici.MostrarTodo();

            foreach (var item in modeloGeneral.BikeList)
            {
                if (string.IsNullOrEmpty(item.Image))
                {
                    item.Image = placeholder;
                }
            }

            modeloGeneral.BrandList = conexionMarca.MostrarMarcas();

            if (filtrar.Brand is null)
            {
                return View(modeloGeneral);
            }
            else
            {
                if (filtrar.Brand.Id == 0)
                {
                    return View(modeloGeneral);
                }
                else
                {
                    modeloGeneral.Brand.Id = filtrar.Brand.Id;
                    return View(modeloGeneral);
                }
            }
        }




        public IActionResult ListComponentes()
        {
            InventoryManager modeloGeneral = new InventoryManager();
            ComponentService conexionComponente = new ComponentService();
            BrandService conexionMarca = new BrandService();
            string placeholder = "/Images/placeholder.jpg";

            modeloGeneral.ComponentList = conexionComponente.MostrarComponente();

            foreach (var item in modeloGeneral.ComponentList)
            {
                if (string.IsNullOrEmpty(item.Component_Image))
                {
                    item.Component_Image = placeholder;
                }
            }
            return View(modeloGeneral);
        }


        public IActionResult ListEventos()
        {
            InventoryManager modeloGeneral = new InventoryManager();
            EventService conexionEvento = new EventService();
            string placeholder = "/Images/placeholder.jpg";

            modeloGeneral.EventList = conexionEvento.MostrarEventos();

            foreach (var item in modeloGeneral.EventList)
            {
                if (string.IsNullOrEmpty(item.Event_Image))
                {
                    item.Event_Image = placeholder;
                }
            }

            return View(modeloGeneral);
        }
    }
}
