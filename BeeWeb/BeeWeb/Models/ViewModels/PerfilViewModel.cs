using System.ComponentModel.DataAnnotations;

namespace BeeWeb.Models.ViewModels
{
    public class PerfilViewModel
    {
        [Required(ErrorMessage ="El nombre del negocio es obligatorio"),
            MinLength(5,ErrorMessage ="Minimo de 5 digitos"),
            MaxLength(50,ErrorMessage ="Maximo de 20 dígitos"),
            Display(Name = "Negocio")] 
        public string NombreNegocio { get; set; } = string.Empty;
        [Required(ErrorMessage ="La dirección es obligatoria"),
            MinLength(5, ErrorMessage = "Minimo de 5 digitos"),
            MaxLength(50, ErrorMessage = "Maximo de 20 dígitos"),
            Display(Name = "Dirección")] 
        public string Direccion { get; set; } = string.Empty;
        [Required(ErrorMessage = "El rubro es obligatorio"),
            MinLength(5, ErrorMessage = "Minimo de 5 digitos"),
            MaxLength(50, ErrorMessage = "Maximo de 20 dígitos"),
            Display(Name = "Rubro del Negocio")]
        public string Rubro { get; set; } = string.Empty;
        [Required(ErrorMessage = "La descripción es obligatoria"),
            MinLength(5, ErrorMessage = "Minimo de 5 digitos"),
            MaxLength(50, ErrorMessage = "Maximo de 20 dígitos"),
            Display(Name = "Descripción breve")]
        public string Descripcion { get; set; } = string.Empty;
        [Required(ErrorMessage = "Especifico el tipo de moneda"),
            MinLength(5, ErrorMessage = "Minimo de 5 digitos"),
            MaxLength(50, ErrorMessage = "Maximo de 20 dígitos"),
            Display(Name = "Descripción breve")]
        public string TipoMoneda { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public string CodigoUsuario { get; set; } = string.Empty;

    }
}
