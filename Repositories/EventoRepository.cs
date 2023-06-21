using AgendaDotNet6MVC.Context;
using AgendaDotNet6MVC.Models;
using AgendaDotNet6MVC.Repositories.Interfaces;

namespace AgendaDotNet6MVC.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly AppDbContext appDbContext;

        public EventoRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Evento> Eventos => appDbContext.Eventos;
    }
}
