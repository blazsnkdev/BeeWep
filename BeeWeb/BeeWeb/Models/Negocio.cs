namespace BeeWeb.Models
{
    public class Negocio
    {
        public Guid NegocioId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Rubro { get; set; }
        public string Descripcion { get; set; }
        public string TipoMoneda { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
