using EBoxOffice.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EBoxOffice.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventService _eventService;

        public HomeController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<IActionResult> Index()
        {
            var events = await _eventService.GetEvents();

            return View(events);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
