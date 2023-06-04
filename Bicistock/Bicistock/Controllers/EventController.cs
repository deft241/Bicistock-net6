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
            string placeholder = "/Images/placeholder.jpg";

            inventoryManager.EventList = eventService.MostrarEventos();

            foreach (var item in inventoryManager.EventList)
            {
                if (string.IsNullOrEmpty(item.Event_Image))
                {
                    item.Event_Image = placeholder;
                }
            }

            return View(inventoryManager);
        }
    }
}
