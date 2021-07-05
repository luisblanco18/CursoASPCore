using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoASPCore.Models
{
    public abstract class ObjetoEscuelaBase
    {
        public string Id { get; set; }
        public string Nombre { get; set; }

        public ObjetoEscuelaBase()
        {
            //UniqueId = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"{Nombre},{Id}";
        }
    }
}
