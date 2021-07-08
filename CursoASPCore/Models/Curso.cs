using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursoASPCore.Models
{
    public class Curso : ObjetoEscuelaBase
    {
        [Required(ErrorMessage ="El nombre del curso es requerido")]
        [StringLength(5)]
        public override string Nombre { get; set; }
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }
        [Display(Prompt ="Dirección de correspondencia", Name ="Address")]
        [Required(ErrorMessage = "Se requiere una dirección")]
        [MinLength(10, ErrorMessage ="La longitud mínima de la dirección es 10")]
        public string Dirección { get; set; }

        public string EscuelaId { get; set; }
        public Escuela Escuela { get; set; }

    }
}
