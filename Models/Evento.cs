namespace AgendaDotNet6MVC.Models
{
    public class Evento
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public DateTime Data { get; set; }


        public virtual Categoria Categoria { get; set; }
    }
}
