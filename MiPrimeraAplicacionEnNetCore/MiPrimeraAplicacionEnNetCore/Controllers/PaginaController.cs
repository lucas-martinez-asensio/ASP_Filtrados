using Microsoft.AspNetCore.Mvc;
using MiPrimeraAplicacionEnNetCore.Clases;
using MiPrimeraAplicacionEnNetCore.Models;

namespace MiPrimeraAplicacionEnNetCore.Controllers
{
    public class PaginaController : Controller
    {
        public IActionResult Index(PaginaCLS oPaginaCLS)
        {
            List<PaginaCLS> listaPagina = new List<PaginaCLS>();
            using(BDHospitalContext db = new BDHospitalContext())
            {
                listaPagina = (from pagina in db.Paginas
                              where pagina.Bhabilitado == 1
                              select new PaginaCLS
                              {
                                  iidPagina = pagina.Iidpagina,
                                  mensaje = pagina.Mensaje,
                                  accion = pagina.Accion,
                                  controlador = pagina.Controlador
                              }).ToList();
                if(oPaginaCLS.mensaje == null)
                {
                    ViewBag.Mensaje = "";
                } else
                {
                    if(oPaginaCLS.mensaje != null)
                    {
                        listaPagina = listaPagina.Where(p => p.mensaje.Contains(oPaginaCLS.mensaje)).ToList();
                    }
                    ViewBag.Mensaje = oPaginaCLS.mensaje;
                }
            }


            return View(listaPagina);
        }
    }
}
