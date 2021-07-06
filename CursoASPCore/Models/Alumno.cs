using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoASPCore.Models
{
    public class Alumno : ObjetoEscuelaBase
    {
        public List<Evaluación> Evaluaciones { get; set; }
        public string CursoId { get; set; }
        public Curso Curso { get; set; }
    }
}
