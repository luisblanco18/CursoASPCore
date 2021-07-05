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
        private EscuelaContext _context;
        public IActionResult Index()
        {
            ViewBag.CosaDinamica = "La monja";
            var escuela = _context.Escuelas.FirstOrDefault();
            return View(escuela);
        }
        public EscuelaController(EscuelaContext context)
        {
            _context = context;
        }
    }
}
