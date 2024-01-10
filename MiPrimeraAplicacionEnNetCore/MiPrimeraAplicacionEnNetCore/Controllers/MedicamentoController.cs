using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MiPrimeraAplicacionEnNetCore.Clases;
using MiPrimeraAplicacionEnNetCore.Models;

namespace MiPrimeraAplicacionEnNetCore.Controllers
{
    public class MedicamentoController : Controller
    {
        public List<SelectListItem> listarFormaFarmaceutica()
        {
            List<SelectListItem> listaFormaFarmaceutica = new List<SelectListItem>();
            using(BDHospitalContext db = new BDHospitalContext())
            {
                listaFormaFarmaceutica = (from formafarma in db.FormaFarmaceuticas
                                         where formafarma.Bhabilitado == 1
                                         select new SelectListItem
                                         {
                                             Text = formafarma.Nombre,
                                             Value = formafarma.Iidformafarmaceutica.ToString()
                                         }).ToList();
                listaFormaFarmaceutica.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
            }
            return listaFormaFarmaceutica;
        }
        public IActionResult Index(MedicamentoCLS oMedicamentoCLS)
        {
            ViewBag.listaForma = listarFormaFarmaceutica();
            List<MedicamentoCLS> listaMedicamento = new List<MedicamentoCLS>();
            using(BDHospitalContext db = new BDHospitalContext())
            {
                if(oMedicamentoCLS.iidFormaFarmaceutica == 0)
                {
                ViewBag.Mensaje = "Mensaje para visualizar en vista";
                listaMedicamento = (from medicamento in db.Medicamentos
                                   join formaFarmaceutica in db.FormaFarmaceuticas
                                   on medicamento.Iidformafarmaceutica equals 
                                   formaFarmaceutica.Iidformafarmaceutica
                                   where medicamento.Bhabilitado == 1
                                   select new MedicamentoCLS
                                   {
                                       iidMedicamento = medicamento.Iidmedicamento,
                                       nombre = medicamento.Nombre,
                                       precio = medicamento.Precio, // o en vez de cambiar el tipo de dato de la clase a decimal? se puede castear este directamente (decimal)medicamento.Precio,
                                       stock = medicamento.Stock, // o en vez de cambiar el tipo de dato de la clase a int? se puede castear este directamente (int)medicamento.Stock, 
                                       formaFarmaceutica = formaFarmaceutica.Nombre
                                   }).ToList();
                } else
                {
                    ViewBag.Mensaje = "Mensaje para visualizar en vista";
                    listaMedicamento = (from medicamento in db.Medicamentos
                                        join formaFarmaceutica in db.FormaFarmaceuticas
                                        on medicamento.Iidformafarmaceutica equals
                                        formaFarmaceutica.Iidformafarmaceutica
                                        where medicamento.Bhabilitado == 1
                                        &&
                                        medicamento.Iidformafarmaceutica == oMedicamentoCLS.iidFormaFarmaceutica
                                        select new MedicamentoCLS
                                        {
                                            iidMedicamento = medicamento.Iidmedicamento,
                                            nombre = medicamento.Nombre,
                                            precio = medicamento.Precio, // o en vez de cambiar el tipo de dato de la clase a decimal? se puede castear este directamente (decimal)medicamento.Precio,
                                            stock = medicamento.Stock, // o en vez de cambiar el tipo de dato de la clase a int? se puede castear este directamente (int)medicamento.Stock, 
                                            formaFarmaceutica = formaFarmaceutica.Nombre
                                        }).ToList();

                }
            }


                return View(listaMedicamento);
        }
    }
}
