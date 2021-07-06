using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoASPCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursoASPCore.Controllers
{
    public class CursoController : Controller
    {
        public IActionResult Index(string Id)
        {
            if (!string.IsNullOrWhiteSpace(Id))
            {
                var cursos = from cur in _context.Cursos
                             where cur.Id == Id
                             select cur;
                return View(cursos.SingleOrDefault());
            }
            else
            {
                return View("MultiCurso", _context.Cursos);
            }

        }
        public IActionResult MultiCurso()
        {
            ViewBag.CosaDinamica = "La monja";
            ViewBag.Fecha = DateTime.Now;
            return View(_context.Cursos);
        }
        public IActionResult Create()
        {

            ViewBag.Fecha = DateTime.Now;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Curso curso)
        {

            ViewBag.Fecha = DateTime.Now;
            var escuela = _context.Escuelas.FirstOrDefault();

            curso.EscuelaId = escuela.Id;
            curso.Id = Guid.NewGuid().ToString();
            _context.Cursos.Add(curso);
            _context.SaveChanges();
            return View();
        }
        private EscuelaContext _context;
        public CursoController(EscuelaContext context)
        {
            _context = context;
        }
    }
}
