using System.ComponentModel.DataAnnotations;

namespace MiPrimeraAplicacionEnNetCore.Clases
{
    public class EspecialidadCLS
    {
        [Display(Name = "Id Especialidad")]
        public int iidespecialidad { get; set; }
        [Display(Name = "Nombre Especialidad")]
        public string nombre { get; set; }
        [Display(Name = "Descripción")]
        public string descripcion { get; set; }
    }
}
