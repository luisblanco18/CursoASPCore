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
            return View("MultiCurso", _context.Cursos);
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
            if (ModelState.IsValid)
            {
                var escuela = _context.Escuelas.FirstOrDefault();

                curso.EscuelaId = escuela.Id;
                curso.Id = Guid.NewGuid().ToString();
                _context.Cursos.Add(curso);
                _context.SaveChanges();
                ViewBag.MensajeExtra = "Curso creado";
                return View("Index",curso);
            }
            else
            {
                return View(curso);
            }

        }
        [Route("Curso/Edit/{id}")]
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Content("Los datos proporcionados no son suficientes.");

            else
                return GetViewCurso("Edit", GetCourse(id));
        }

        //[HttpPut("{id}")]
        [HttpPost]
        [Route("Curso/Edit/{pCursoId}")]
        public IActionResult Edit(Curso pCurso, string pCursoId)
        {
            if (ModelState.IsValid)
                return SaveCourse(1, pCurso, pCursoId);

            else
                return View(pCurso);
        }
        [Route("Curso/Delete/{id}")]
        public IActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Content("Los datos proporcionados no son suficientes.");

            else
                return GetViewCurso("Delete", GetCourse(id));
        }

        [HttpPost]
        [Route("Curso/Delete/{pCursoId}")]
        public IActionResult Delete(Curso pCurso, string pCursoId)
        {
            if (ModelState.IsValid)
                return SaveCourse(2, pCurso, pCursoId);

            else
                return MultiCurso();
        }

        private IActionResult GetViewCurso(string pAccion, Curso pCurso)
        {
            bool cursoEsNull = CursoIsNull(pCurso);
            if (cursoEsNull)
                return Content("Curso no encontrado.");

            else
                return View(pAccion, pCurso);
        }
        private bool CursoIsNull(Curso pCurso)
        {
            return pCurso == null;
        }
        private Curso GetCourse(string pCursoId)
        {
            var cursosResults = from curso in _context.Cursos
                                where curso.Id == pCursoId
                                select curso;

            return cursosResults.SingleOrDefault();
        }
        private IActionResult SaveCourse(short pTipoManage, Curso pCurso, string pCursoId)
        {
            pCurso.Id = pCursoId;
            ManageCourseDataBase(pTipoManage, pCurso);
            _context.SaveChanges();
            return MultiCurso();
        }

        private void ManageCourseDataBase(short pTipoManage, Curso pCurso)
        {
            switch (pTipoManage)
            {
                case 1:
                    _context.Cursos.Update(pCurso);
                    break;
                case 2:
                    _context.Cursos.Remove(pCurso);
                    break;
                case 3:
                    pCurso.EscuelaId = _context.Escuelas.FirstOrDefault().Id;
                    _context.Cursos.Add(pCurso);
                    break;
                default:
                    break;
            }
        }
        private EscuelaContext _context;
        public CursoController(EscuelaContext context)
        {
            _context = context;
        }
    }
}
