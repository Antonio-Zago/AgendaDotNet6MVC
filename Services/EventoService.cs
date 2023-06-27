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

        public IEnumerable<IGrouping<string, EventoListViewModel>> GetEventos()
        {
            var eventos = eventoRepository.Eventos.OrderBy(e => e.Data);
            List<EventoListViewModel> eventosListViewModel = new List<EventoListViewModel>();

            foreach (var evento in eventos)
            {
                var eventoListViewModel = new EventoListViewModel
                {
                    Id = evento.Id,
                    Nome = evento.Nome,
                    Data = evento.Data.Date.ToString("dd/MM/yyyy"),
                    Hora = evento.Data.Date.ToString("hh:mm"),
                    DiaSemana = new CultureInfo("pt-BR").DateTimeFormat.GetDayName(evento.Data.DayOfWeek)
                };

                VerificarindicadorData(eventoListViewModel, evento);
                eventosListViewModel.Add(eventoListViewModel);


            }

            return eventosListViewModel.GroupBy(e => e.IndicadorData);
        }

        private void VerificarindicadorData(EventoListViewModel eventoListViewModel, Evento evento)
        {
            if (evento.Data.Date < DateTime.Today.Date)
            {
                eventoListViewModel.IndicadorData = "Eventos passados";
            }
            else if (evento.Data.Date == DateTime.Today.Date)
            {
                eventoListViewModel.IndicadorData = "Hoje";

            }
            else if (evento.Data.Date == DateTime.Today.Date.AddDays(1))
            {
                eventoListViewModel.IndicadorData = "Amanhã";
            }
            else if (VerificarSeDiaEstaNessaSemana(evento.Data) )
            {
                eventoListViewModel.IndicadorData = "Essa semana";
            }
            else if (VerificarSeDiaEsteMes(evento.Data))
            {
                eventoListViewModel.IndicadorData = "Esse mês";
            }
            else 
            {
                eventoListViewModel.IndicadorData = new CultureInfo("pt-BR").DateTimeFormat.GetMonthName(evento.Data.Month);
            }
            

        }

        private bool VerificarSeDiaEstaNessaSemana(DateTime dia)
        {
            var diaSemanaHoje = DateTime.Today.DayOfWeek;
            var diaSemanaDia = dia.DayOfWeek;

            if (dia.Date >= DateTime.Today.Date && dia.Date <= DateTime.Today.Date.AddDays(7) && diaSemanaDia> diaSemanaHoje)
            {
                return true;
            }
            return false;

        }

        private bool VerificarSeDiaEsteMes(DateTime dia)
        {
            var diaSemanaHoje = DateTime.Today.DayOfWeek;
            var diaSemanaDia = dia.DayOfWeek;

            if (dia.Date >= DateTime.Today.Date && dia.Month == DateTime.Today.Month && dia.Year == DateTime.Today.Year)
            {
                return true;
            }
            return false;
        }
    }
}
