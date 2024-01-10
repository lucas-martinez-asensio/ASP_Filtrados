﻿using System.ComponentModel.DataAnnotations;

namespace MiPrimeraAplicacionEnNetCore.Clases
{
    public class PersonaCLS
    {
        [Display(Name = "Id Persona")]
        public int iidPersona { get; set; }
        [Display(Name = "Nombre Completo")]
        public string nombreCompleto { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Nombre Sexo")]
        public string nombreSexo { get; set; }

        public int iidSexo { get; set; }

    }
}
