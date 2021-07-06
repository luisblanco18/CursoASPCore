using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CursoASPCore.Models;

namespace CursoASPCore.Controllers
{
    public class AsignaturaController : Controller
    {
        public IActionResult Index()
        {
            return View(_context.Asignaturas.FirstOrDefault());
        }
        public IActionResult MultiAsignatura()
        {
            
            ViewBag.CosaDinamica = "La monja";
            ViewBag.Fecha = DateTime.Now;
            return View(_context.Asignaturas);
        }
        private EscuelaContext _context;
        public AsignaturaController(EscuelaContext context)
        {
            _context = context;
        }
    }
}
