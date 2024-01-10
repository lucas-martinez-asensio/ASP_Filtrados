using Microsoft.AspNetCore.Mvc;
using MiPrimeraAplicacionEnNetCore.Clases;


namespace MiPrimeraAplicacionEnNetCore.Controllers
{
    public class PaisController : Controller
    {
        public IActionResult Inicio()
        {
            return View();
        }

        public IActionResult Lista()
        {
            return View();
        }

        public IActionResult PruebaLista()
        {
            List<InstructorCLS> lista = new List<InstructorCLS>();
            InstructorCLS oInstructorCLS = new InstructorCLS();
            oInstructorCLS.nombre = "Lucas";
            oInstructorCLS.aMatern = "ola";
            lista.Add(oInstructorCLS);
            oInstructorCLS = new InstructorCLS();
            oInstructorCLS.nombre = "Tati";
            oInstructorCLS.aPatern = "Da Fonte";
            lista.Add(oInstructorCLS);
            return View(lista);
        }

        public string bienvenido()
        {
            return "bienvenido al curso de ASP.NET Core";
        }

        public string saludo(InstructorCLS oInstructorCLS)
        {
            return "Hola cómo estás " + oInstructorCLS.nombre + " el a matern es " + oInstructorCLS.aMatern;
        }

        public string saludoPais(string nombrePais)
        {
            return "Hola cómo estás " + nombrePais;
        }

        public InstructorCLS mostrarInstructor()
        {
            InstructorCLS oInstructorCLS = new InstructorCLS();
            oInstructorCLS.nombre = "Lucas";
            oInstructorCLS.aMatern = "ola";
            return oInstructorCLS;
        }

        public List<InstructorCLS> listaInstructor()
        {
            List<InstructorCLS> lista = new List<InstructorCLS>();
            InstructorCLS oInstructorCLS = new InstructorCLS();
            oInstructorCLS.nombre = "Lucas";
            oInstructorCLS.aMatern = "ola";
            lista.Add(oInstructorCLS);
            oInstructorCLS = new InstructorCLS();
            oInstructorCLS.nombre = "Tati";
            oInstructorCLS.aPatern = "Da Fonte";
            lista.Add(oInstructorCLS);
            return lista;
        }
    }
}
