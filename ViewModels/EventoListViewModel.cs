using AgendaDotNet6MVC.Models;

namespace AgendaDotNet6MVC.ViewModels
{
    public class EventoListViewModel
    {

        public int Id { get; set; }
        public string Nome { get; set; }

        public string Data { get; set; }

        public string Hora { get; set; }

        public string DiaSemana { get; set; }

        public string IndicadorData { get; set; }


    }
}
