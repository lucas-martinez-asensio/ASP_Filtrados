using System.ComponentModel.DataAnnotations;

namespace MiPrimeraAplicacionEnNetCore.Clases
{
    public class MedicamentoCLS
    {
        [Display(Name = "ID Medicamento")]
        public int iidMedicamento { get; set; }

        [Display(Name = "Nombre común")]
        public string nombre { get; set; }

        [Display(Name = "Precio")]
        public float? precio { get; set; }

        [Display(Name = "Stock")]
        public int? stock { get; set; }

        [Display(Name = "Forma Farmacéutica")]
        public string formaFarmaceutica { get; set; }

        public int iidFormaFarmaceutica { get; set; }
    }
}
