using System;
using System.Collections.Generic;

namespace Instituto.Models
{
    public partial class Bloque
    {
        public Bloque()
        {
            Matriculas = new HashSet<Matricula>();
        }

        public int IdBloque { get; set; }
        public string NombreBloque { get; set; } = null!;
        public DateTime PeriodoBloque { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
