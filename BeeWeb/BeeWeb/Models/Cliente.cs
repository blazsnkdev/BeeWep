namespace BeeWeb.Models
{
    public class Cliente
    {
        public Guid ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
