using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoASPCore.Models
{
    public class EscuelaContext : DbContext
    {
        public DbSet<Escuela> Escuelas { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Evaluación> Evaluaciones { get; set; }

        public EscuelaContext(DbContextOptions<EscuelaContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var escuela = new Escuela();
            escuela.Id = Guid.NewGuid().ToString();
            escuela.Nombre = "Platzi School";
            escuela.AñoDeCreación = 2021;
            escuela.Ciudad = "La Paz";
            escuela.Pais = "Bolivia";
            escuela.Dirección = "Av. Siempre Viva";
            escuela.TipoEscuela = TiposEscuela.Secundaria;

            //Cargar Cursos de la Escuela
            var cursos = CargarCursos(escuela);

            //x cada curso cargar asignaturas
            var asignaturas = CargarAsignaturas(cursos);

            //x cada curso cargar alumnos
            var alumnos = CargarAlumnos(cursos);

            //x cada Evaluacion cargar alumnos y asignatura
            var evaluaciones = CargarEvaluaciones(cursos, asignaturas, alumnos);

            modelBuilder.Entity<Escuela>().HasData(escuela);
            modelBuilder.Entity<Curso>().HasData(cursos.ToArray());
            modelBuilder.Entity<Asignatura>().HasData(asignaturas.ToArray());
            modelBuilder.Entity<Alumno>().HasData(alumnos.ToArray());
            modelBuilder.Entity<Evaluación>().HasData(evaluaciones.ToArray());

        }
        private List<Alumno> CargarAlumnos(List<Curso> cursos)
        {
            var listaAlumnos = new List<Alumno>();

            Random rnd = new Random();
            foreach (var curso in cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                var tmplist = GenerarAlumnosAlAzar(curso, cantRandom);
                listaAlumnos.AddRange(tmplist);
            }
            return listaAlumnos;
        }

        private static List<Asignatura> CargarAsignaturas(List<Curso> cursos)
        {
            var listaCompleta = new List<Asignatura>();
            foreach (var curso in cursos)
            {
                var tmpList = new List<Asignatura> {
                            new Asignatura{
                                Id = Guid.NewGuid().ToString(),
                                CursoId = curso.Id,
                                Nombre="Matemáticas"} ,
                            new Asignatura{Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Nombre="Educación Física"},
                            new Asignatura{Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Nombre="Castellano"},
                            new Asignatura{Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Nombre="Ciencias Naturales"},
                            new Asignatura{Id = Guid.NewGuid().ToString(),CursoId = curso.Id, Nombre="Programación"}

                };
                listaCompleta.AddRange(tmpList);
                //curso.Asignaturas = tmpList;
            }

            return listaCompleta;
        }

        private static List<Curso> CargarCursos(Escuela escuela)
        {
            return new List<Curso>(){
                        new Curso{
                            Id = Guid.NewGuid().ToString(),
                            EscuelaId = escuela.Id,
                            Nombre = "101",
                            Dirección = "Avenida Siempre viva",
                            Jornada = TiposJornada.Mañana },
                        new Curso{Id = Guid.NewGuid().ToString(),EscuelaId = escuela.Id, Nombre = "201",Dirección = "Avenida Siempre viva", Jornada = TiposJornada.Mañana},
                        new Curso{Id = Guid.NewGuid().ToString(),EscuelaId = escuela.Id, Nombre = "301",Dirección = "Avenida Siempre viva", Jornada = TiposJornada.Mañana},
                        new Curso{Id = Guid.NewGuid().ToString(),EscuelaId = escuela.Id, Nombre = "401",Dirección = "Avenida Siempre viva", Jornada = TiposJornada.Tarde},
                        new Curso{Id = Guid.NewGuid().ToString(),EscuelaId = escuela.Id, Nombre = "501",Dirección = "Avenida Siempre viva", Jornada = TiposJornada.Tarde},
            };
        }

        private List<Alumno> GenerarAlumnosAlAzar(Curso curso, int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno
                               {
                                   Id = Guid.NewGuid().ToString(),
                                   CursoId = curso.Id,
                                   Nombre = $"{n1} {n2} {a1}"
                               };

            return listaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();
        }

        private List<Evaluación> CargarEvaluaciones(List<Curso> cursos, List<Asignatura> asignaturas, List<Alumno> alumnos, int numeroEvaluaciones = 5)
        {
            Random rnd = new Random();
            var listaEv = new List<Evaluación>();
            foreach (var curso in cursos)
            {
                foreach (var asignatura in asignaturas)
                {
                    foreach (var alumno in alumnos)
                    {
                        for (int i = 0; i < numeroEvaluaciones; i++)
                        {
                            int cantRandom = rnd.Next(0, 500);
                            var tmp = new List<Evaluación> {
                        new Evaluación {
                            Id = Guid.NewGuid().ToString(),
                            Nombre = "Evaluación de " + asignatura.Nombre + " # " + (i + 1),
                            AlumnoId = alumno.Id,
                            //Alumno = alumno,
                            AsignaturaId = asignatura.Id,
                            //Asignatura = asignatura,
                            Nota = (float)cantRandom/100
                        }
                    };
                            listaEv.AddRange(tmp);
                        }
                    }
                }
            }

            return listaEv;
        }

    }
}
