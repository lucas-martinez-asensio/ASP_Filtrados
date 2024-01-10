using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiPrimeraAplicacionEnNetCore.Clases;
using MiPrimeraAplicacionEnNetCore.Models;

namespace MiPrimeraAplicacionEnNetCore.Controllers
{
    public class TipoUsuarioController : Controller
    {
        // GET: TipoUsuario
        public ActionResult Index(TipoUsuarioCLS oTipoUsuarioCLS)
        {
            List<TipoUsuarioCLS> listaTipoUsu = new List<TipoUsuarioCLS>();
            using(BDHospitalContext db = new BDHospitalContext())
            {
                listaTipoUsu = (from tipousu in db.TipoUsuarios
                                where tipousu.Bhabilitado == 1
                                select new TipoUsuarioCLS
                                {
                                    iidTipoUsuario = tipousu.Iidtipousuario,
                                    nombre = tipousu.Nombre,
                                    descripcion = tipousu.Descripcion
                                }).ToList();
            if(oTipoUsuarioCLS.nombre == null && oTipoUsuarioCLS.descripcion == null && oTipoUsuarioCLS.iidTipoUsuario == 0)
                {
                    ViewBag.Nombre = "";
                    ViewBag.Descripcion = "";
                    ViewBag.IidTipoUsuario = 0;
                }
                else
                {
                    if(oTipoUsuarioCLS.nombre != null)
                    {
                        listaTipoUsu = listaTipoUsu.Where(p => p.nombre.Contains(oTipoUsuarioCLS.nombre)).ToList();
                    }
                    if (oTipoUsuarioCLS.iidTipoUsuario != 0)
                    {
                        listaTipoUsu = listaTipoUsu.Where(p => p.iidTipoUsuario == oTipoUsuarioCLS.iidTipoUsuario).ToList();
                    }
                    if (oTipoUsuarioCLS.descripcion != null)
                    {
                        listaTipoUsu = listaTipoUsu.Where(p => p.descripcion.Contains(oTipoUsuarioCLS.nombre)).ToList();
                    }
                    ViewBag.Nombre = oTipoUsuarioCLS.nombre;
                    ViewBag.Descripcion = oTipoUsuarioCLS.descripcion;
                    ViewBag.IidTipoUsuario = oTipoUsuarioCLS.iidTipoUsuario;
                }
            }
            return View(listaTipoUsu);
        }

        // GET: TipoUsuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoUsuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoUsuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoUsuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoUsuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoUsuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoUsuario/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
