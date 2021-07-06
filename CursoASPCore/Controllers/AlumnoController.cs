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
        
        public IActionResult Index(string Id)
        {
            if (!string.IsNullOrWhiteSpace(Id))
            {
                var alumnos = from alum in _context.Alumnos
                                 where alum.Id == Id
                                 select alum;
                return View(alumnos.SingleOrDefault());
            }
            else
            {
                return View("MultiAlumno", _context.Alumnos);
            }

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
