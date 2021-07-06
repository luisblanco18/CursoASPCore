using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CursoASPCore.Models;

namespace CursoASPCore.Controllers
{
    public class AlumnoController : Controller
    {
        public IActionResult Index()
        {
            return View(_context.Alumnos.FirstOrDefault());
        }
        public IActionResult MultiAlumno()
        {
            ViewBag.CosaDinamica = "La monja";
            ViewBag.Fecha = DateTime.Now;
            return View(_context.Alumnos);
        }
        
        private EscuelaContext _context;
        public AlumnoController(EscuelaContext context)
        {
            _context = context;
        }
    }
}
