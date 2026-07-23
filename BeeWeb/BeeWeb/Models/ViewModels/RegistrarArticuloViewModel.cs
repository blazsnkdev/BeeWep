using System.ComponentModel.DataAnnotations;

namespace BeeWeb.Models.ViewModels
{
    public class RegistrarArticuloViewModel
    {
        [Required(ErrorMessage = "La categoria es necesesaria")]
        public Guid CategoriaId { get; set; }
        [Required(ErrorMessage = "La categoria es necesesaria")]
        public Guid MarcaId { get; set; }
        [Required(ErrorMessage = "El número de parte es obligatorio")]
        public string NumeroParte { get; set; } = string.Empty;
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public bool PermiteSerie { get; set; } = false;
        [Required(ErrorMessage = "La unidad de medida es obligatorio")]
        public string UnidadMedida { get; set; } = string.Empty;
    }
}
