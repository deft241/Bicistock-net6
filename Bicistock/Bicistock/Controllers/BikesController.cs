using Bicistock.Common.Models;
using Bicistock.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bicistock.Controllers
{
    public class BikesController : Controller
    {
        public IActionResult Index()
        {
            BrandService brandService = new BrandService();
            InventoryManager inventoryManager = new InventoryManager();
            BikeService bikeService = new BikeService();

            string placeholder = "/Images/placeholder.jpg";

            inventoryManager.BikeList = bikeService.MostrarTodo();

            foreach (var item in inventoryManager.BikeList)
            {
                if (string.IsNullOrEmpty(item.Image))
                {
                    item.Image = placeholder;
                }
            }
            inventoryManager.BrandList = brandService.MostrarMarcas();

            return View(inventoryManager);
        }


        [HttpPost]
        public IActionResult Index(InventoryManager filtrar)
        {
            BrandService brandService = new BrandService();
            InventoryManager inventoryManager = new InventoryManager();
            BikeService bikeService = new BikeService();
            string placeholder = "/Images/placeholder.jpg";
            inventoryManager.Brand = new Brand();

            inventoryManager.BikeList = bikeService.MostrarTodo();

            foreach (var item in inventoryManager.BikeList)
            {
                if (string.IsNullOrEmpty(item.Image))
                {
                    item.Image = placeholder;
                }
            }

            inventoryManager.BrandList = brandService.MostrarMarcas();

            if (filtrar.Brand is null)
            {
                return View(inventoryManager);
            }
            else
            {
                if (filtrar.Brand.Id == 0)
                {
                    return View(inventoryManager);
                }
                else
                {
                    inventoryManager.Brand.Id = filtrar.Brand.Id;
                    return View(inventoryManager);
                }
            }
        }
    }
}
