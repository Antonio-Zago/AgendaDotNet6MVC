using AgendaDotNet6MVC.Models;

namespace AgendaDotNet6MVC.Repositories.Interfaces
{
    public interface IEventoRepository
    {
        IEnumerable<Evento> Eventos { get; }
    }
}
