namespace BeeWeb.Models
{
    public class Categoria
    {
        public Guid CategoriaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<Articulo> Articulos { get; set; } = new List<Articulo>();
    }
}
