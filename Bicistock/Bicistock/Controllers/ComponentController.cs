using Bicistock.Common.Models;
using Bicistock.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bicistock.Controllers
{
    public class ComponentController : Controller
    {
        public IActionResult Index()
        {
            InventoryManager inventoryManager = new InventoryManager();
            ComponentService componentService = new ComponentService();
            BrandService brandService = new BrandService();

            string placeholder = "/Images/placeholder.jpg";

            inventoryManager.BrandList = brandService.MostrarMarcas();
            inventoryManager.ComponentList = componentService.MostrarComponente();

            foreach (var item in inventoryManager.ComponentList)
            {
                if (string.IsNullOrEmpty(item.Component_Image))
                {
                    item.Component_Image = placeholder;
                }
            }
            return View(inventoryManager);
        }

        [HttpPost]
        public IActionResult Index(InventoryManager filtrar)
        {
            BrandService brandService = new BrandService();
            InventoryManager inventoryManager = new InventoryManager();
            ComponentService componentService = new ComponentService();
            string placeholder = "/Images/placeholder.jpg";
            inventoryManager.Brand = new Brand();

            inventoryManager.ComponentList = componentService.ShowBrandComponent(filtrar.Brand.Id);

            foreach (var item in inventoryManager.ComponentList)
            {
                if (string.IsNullOrEmpty(item.Component_Image))
                {
                    item.Component_Image = placeholder;
                }
            }

            inventoryManager.BrandList = brandService.MostrarMarcas();

            if (filtrar.Brand is null || filtrar.Brand.Id == 0)
            {
                inventoryManager.ComponentList = componentService.MostrarComponente();
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
