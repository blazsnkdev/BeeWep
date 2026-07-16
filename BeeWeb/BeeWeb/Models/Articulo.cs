namespace BeeWeb.Models
{
    public class Articulo
    {
        public Guid ArticuloId { get; set; }
        public string NumeroParte { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Categoria Categoria { get; set; }
        public Guid CategoriaId { get; set; }
        public Marca Marca { get; set; }
        public Guid MarcaId { get; set; }
        public bool PermiteSeries { get; set; }
        public string UnidadMedida { get; set; }
    }
    public class ArticuloSerie
    {
        public Guid ArticuloSerieId { get; set; }
        public Guid ArticuloId { get; set; }
        public Articulo Articulo { get; set; }
        public double PrecioCompra { get; set; }
        public double PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public string Serie { get; set; }
    }
}
