using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoASPCore.Models
{
    public class Evaluación : ObjetoEscuelaBase
    {
        public Alumno Alumno { get; set; }
        public string AlumnoId { get; set; }
        public Asignatura Asignatura { get; set; }
        public string AsignaturaId { get; set; }

        public float Nota { get; set; }

        public override string ToString()
        {
            return $"{Nota}, {Alumno.Nombre}, {Asignatura.Nombre}";
        }
    }
}
