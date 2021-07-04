using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoASPCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursoASPCore.Controllers
{
    public class EscuelaController : Controller
    {
        public IActionResult Index()
        {
            var escuela = new Escuela();
            escuela.UniqueId = Guid.NewGuid().ToString();
            escuela.Nombre = "Platzi School";
            escuela.AñoDeCreación = 2021;
            escuela.Ciudad = "La Paz";
            escuela.Pais = "Bolivia";
            escuela.Dirección = "Av. Siempre Viva";
            escuela.TipoEscuela = TiposEscuela.Secundaria;
            ViewBag.CosaDinamica = "La monja";
            return View(escuela);
        }
    }
}
