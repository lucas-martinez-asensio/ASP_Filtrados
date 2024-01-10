﻿using Microsoft.AspNetCore.Mvc;
using MiPrimeraAplicacionEnNetCore.Clases;
using MiPrimeraAplicacionEnNetCore.Models;

namespace MiPrimeraAplicacionEnNetCore.Controllers
{
    public class SedeController : Controller
    {
        public IActionResult Index(SedeCLS oSedeCLS)
        {

            List<SedeCLS> listaSede = new List<SedeCLS>();
            using(BDHospitalContext db = new BDHospitalContext())
            {
                if(oSedeCLS.nombreSede == "" || oSedeCLS.nombreSede == null )
                {
                    listaSede = (from sede in db.Sedes
                            where sede.Bhabilitado == 1
                            select new SedeCLS
                            {
                                iidSede = sede.Iidsede,
                                nombreSede = sede.Nombre,
                                direccion = sede.Direccion
                            }).ToList();
                    ViewBag.nombreSede = "";
                } else
                {
                    listaSede = (from sede in db.Sedes
                                 where sede.Bhabilitado == 1
                                 && sede.Nombre.Contains(oSedeCLS.nombreSede)
                                 select new SedeCLS
                                 {
                                     iidSede = sede.Iidsede,
                                     nombreSede = sede.Nombre,
                                     direccion = sede.Direccion
                                 }).ToList();
                    ViewBag.nombreSede = oSedeCLS.nombreSede;
                }

            }
            
            return View(listaSede);

        }
    }
}
