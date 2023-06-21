using AgendaDotNet6MVC.Models;
using AgendaDotNet6MVC.Repositories.Interfaces;
using AgendaDotNet6MVC.ViewModels;
using System.Globalization;

namespace AgendaDotNet6MVC.Services
{
    public class EventoService
    {
        private readonly IEventoRepository eventoRepository;

        public EventoService(IEventoRepository eventoRepository)
        {
            this.eventoRepository = eventoRepository;
        }

        public List<EventoListViewModel> GetEventos()
        {
            var eventos = eventoRepository.Eventos.OrderBy(e => e.Data);
            List<EventoListViewModel> eventosListViewModel = new List<EventoListViewModel>();

            foreach (var evento in eventos)
            {
                var eventoListViewModel = new EventoListViewModel
                {
                    Nome = evento.Nome,
                    Data = evento.Data.Date.ToString("dd/MM/yyyy"),
                    Hora = evento.Data.Date.ToString("hh:mm"),
                    DiaSemana = new CultureInfo("pt-BR").DateTimeFormat.GetDayName(evento.Data.DayOfWeek)
                };

                eventosListViewModel.Add(eventoListViewModel);


            }

            return eventosListViewModel;
        }
    }
}
