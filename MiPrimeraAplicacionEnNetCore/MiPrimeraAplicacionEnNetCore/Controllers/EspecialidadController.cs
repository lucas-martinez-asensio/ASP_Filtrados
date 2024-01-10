using Microsoft.AspNetCore.Mvc;
using MiPrimeraAplicacionEnNetCore.Clases;
using MiPrimeraAplicacionEnNetCore.Models;

namespace MiPrimeraAplicacionEnNetCore.Controllers
{
    public class EspecialidadController : Controller
    {
        public IActionResult Index(EspecialidadCLS oEspecialidadCLS)
        {
            ViewBag.nombreEspecialidad = "";
            List<EspecialidadCLS> listaEspecialidad = new List<EspecialidadCLS>();
            using (BDHospitalContext db = new BDHospitalContext()){
            if(oEspecialidadCLS.nombre == null || oEspecialidadCLS.nombre == "") {
                    listaEspecialidad = (from especialidad in db.Especialidads
                                         where especialidad.Bhabilitado == 1
                                         select new EspecialidadCLS
                                         {
                                             iidespecialidad = especialidad.Iidespecialidad,
                                             nombre = especialidad.Nombre,
                                             descripcion = especialidad.Descripcion
                                         }).ToList();
                    ViewBag.nombreEspecialidad = "";
            } 
            else 
            {
                    listaEspecialidad = (from especialidad in db.Especialidads
                                        where especialidad.Bhabilitado == 1
                                        && especialidad.Nombre.Contains(oEspecialidadCLS.nombre) // importante acá debe estar correctamente detallado como name del input text donde mostrar con el valor del atributo en este caso nombre
                                        select new EspecialidadCLS
                                        {
                                             iidespecialidad = especialidad.Iidespecialidad,
                                             nombre = especialidad.Nombre,
                                             descripcion = especialidad.Descripcion
                                        }).ToList();
                    ViewBag.nombreEspecialidad = oEspecialidadCLS.nombre;
                    }
            }
            return View(listaEspecialidad);
        }

        public IActionResult Agregar() 
        {
            return View();        
        }
    }
}
