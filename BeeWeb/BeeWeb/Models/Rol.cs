namespace BeeWeb.Models
{
    public class Rol
    {
        public Guid RolId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
