namespace BeeWeb.Models
{
    public class Marca
    {
        public Guid MarcaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public ICollection<Articulo> Articulos { get; set; } = new List<Articulo>();
    }
}
