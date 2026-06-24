using System.ComponentModel.DataAnnotations;

namespace BeeWeb.Models
{
    public class Usuario
    {
        [Key]
        public Guid UsurioId { get; set; }
        public string Nombre { get; set; }
        public string PasswordHashed { get; set; }
        public Cliente Cliente { get; set; }
        public Guid UsuarioRolId { get; set; }
        public ICollection<Rol> Roles { get; set; }
    }
}
