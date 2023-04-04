using Bicistock.Common.Models;
using Bicistock.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace Bicistock.Controllers
{
    public class BikesController : Controller
    {
        public IActionResult Index()
        {
            CN_Marca conexionMarca = new CN_Marca();
            CS_Marca Brand = new CS_Marca();




            CS_ModeloGeneral modeloGeneral = new CS_ModeloGeneral();
            List<CS_Bici> listabicis = new List<CS_Bici>();
            CN_Bici conexionBici = new CN_Bici();
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
        public IActionResult Index(CS_ModeloGeneral filtrar)
        {
            CN_Marca conexionMarca = new CN_Marca();
            CS_Marca Brand = new CS_Marca();

            CS_ModeloGeneral modeloGeneral = new CS_ModeloGeneral();
            List<CS_Bici> listabicis = new List<CS_Bici>();
            CN_Bici conexionBici = new CN_Bici();
            string placeholder = "/Images/placeholder.jpg";
            modeloGeneral.Brand = new CS_Marca();

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
            CS_ModeloGeneral modeloGeneral = new CS_ModeloGeneral();
            CN_Componente conexionComponente = new CN_Componente();
            CN_Marca conexionMarca = new CN_Marca();
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
            CS_ModeloGeneral modeloGeneral = new CS_ModeloGeneral();
            CN_Evento conexionEvento = new CN_Evento();
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
