using System.ComponentModel.DataAnnotations;

namespace MiPrimeraAplicacionEnNetCore.Clases
{
    public class PaginaCLS
    {
        public int iidPagina { get; set; }
        public string mensaje { get; set; }
        [Display(Name = "Accion")]
        public string accion { get; set; }
        [Display(Name = "Controlador")]
        public string controlador { get; set; }
    }
}
