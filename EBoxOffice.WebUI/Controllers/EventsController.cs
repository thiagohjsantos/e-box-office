using EBoxOffice.Application.DTOs;
using EBoxOffice.Application.Interfaces;
using EBoxOffice.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EBoxOffice.WebUI.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventService _eventService;
        private readonly ICategoryService _categoryService;
        private readonly ITicketService _ticketService;
        private readonly IWebHostEnvironment _environment;

        public EventsController(IEventService eventService, ICategoryService categoryService,
            ITicketService ticketService, IWebHostEnvironment environment)
        {
            _eventService = eventService;
            _categoryService = categoryService;
            _ticketService = ticketService;
            _environment = environment;
        }

        [Authorize(Roles = "Company")]
        public async Task<IActionResult> Index()
        {
            var events = await _eventService.GetEvents();
            return View(events);
        }

        [HttpGet]
        [Authorize(Roles = "Company")]
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId =
                new SelectList(await _categoryService.GetCategories(), "Id", "Name");

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Company")]
        public async Task<IActionResult> Create(EventDTO eventDTO, int ticketQTD)
        {
            ViewBag.CategoryId =
                new SelectList(await _categoryService.GetCategories(), "Id", "Name");

            if (ModelState.IsValid)
            {
                await _eventService.Add(eventDTO);

                var eventId = _eventService.GetEvents().Result.Last().Id;

                eventDTO.Tickets.EventId = eventId;

                for (int i = 0; i < ticketQTD; i++)
                {

                    await _ticketService.Add(eventDTO.Tickets);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(eventDTO);
        }

        [HttpGet]
        [Authorize(Roles = "Company")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var eventVM = await _eventService.GetById(id);

            if (eventVM == null) return NotFound();

            var categories = await _categoryService.GetCategories();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name", eventVM.CategoryId);

            ViewBag.ticketQTD = _ticketService.GetTickets().Result.Count(x => x.EventId == eventVM.Id);

            return View(eventVM);
        }

        [HttpPost]
        [Authorize(Roles = "Company")]
        public async Task<IActionResult> Edit(EventDTO eventDTO, int ticketQTD)
        {
            ViewBag.CategoryId =
               new SelectList(await _categoryService.GetCategories(), "Id", "Name");

            ViewBag.ticketQTD = _ticketService.GetTickets().Result.Count(x => x.EventId == eventDTO.Id);

            var tickets = _ticketService.GetTickets().Result.Where(t => t.EventId == eventDTO.Id);

            if (ModelState.IsValid)
            {
                await _eventService.Update(eventDTO);

                return RedirectToAction(nameof(Index));
            }
            return View(eventDTO);
        }

        [HttpGet]
        [Authorize(Roles = "Company")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var eventVM = await _eventService.GetById(id);

            if (eventVM == null) return NotFound();

            return View(eventVM);
        }

        [HttpPost(), ActionName("Delete")]
        [Authorize(Roles = "Company")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _eventService.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Company,User")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var eventVM = await _eventService.GetById(id);

            if (eventVM == null) return NotFound();

            var wwwroot = _environment.WebRootPath;
            var image = Path.Combine(wwwroot, "images\\" + eventVM.Image);
            var exists = System.IO.File.Exists(image);
            ViewBag.ImageExist = exists;

            ViewBag.ticketQTD = _ticketService.GetTickets().Result.Count(x => x.EventId == eventVM.Id);
            ViewBag.ticketPrice = _ticketService.GetTickets().Result.Where(x => x.EventId == eventVM.Id).First().Price;

            return View(eventVM);
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Buy(int? id)
        {
            if (id == null) return NotFound();

            var eventVM = await _eventService.GetById(id);

            if (eventVM == null) return NotFound();

            ViewBag.ticketPrice = _ticketService.GetTickets().Result.Where(x => x.EventId == eventVM.Id).First().Price;

            ViewBag.paymentMethods = new SelectList((PaymentMethodViewModel[])Enum.GetValues(typeof(PaymentMethodViewModel)));


            return View(eventVM);
        }

        private static async Task UploadImage(IFormFile fileImage, EventDTO eventDTO)
        {
            var fileName = Path.GetFileName(fileImage.FileName);

            var myUniqueFileName = Convert.ToString(Guid.NewGuid());

            var fileExtension = Path.GetExtension(fileName);

            var newFileName = String.Concat(myUniqueFileName, fileExtension);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", newFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await fileImage.CopyToAsync(stream);
            }

            eventDTO.Image = newFileName;

        }
    }
}
