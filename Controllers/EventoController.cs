using AgendaDotNet6MVC.Repositories;
using AgendaDotNet6MVC.Repositories.Interfaces;
using AgendaDotNet6MVC.Services;
using AgendaDotNet6MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AgendaDotNet6MVC.Controllers
{
    public class EventoController : Controller
    {
        private readonly EventoService eventoService;

        public EventoController(EventoService eventoService)
        {
            this.eventoService = eventoService;
        }

        public IActionResult List()
        {
            var eventosListViewModel = eventoService.GetEventos();


            return View(eventosListViewModel);
        }
    }
}
