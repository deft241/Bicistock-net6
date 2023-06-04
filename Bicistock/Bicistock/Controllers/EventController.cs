using Bicistock.Common.Models;
using Bicistock.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bicistock.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            InventoryManager inventoryManager = new InventoryManager();
            EventService eventService = new EventService();

            inventoryManager.EventList = eventService.MostrarEventos();


            return View(inventoryManager);
        }
    }
}
