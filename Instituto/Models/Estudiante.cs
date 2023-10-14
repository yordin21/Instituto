using System;
using System.Collections.Generic;

namespace Instituto.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            Matriculas = new HashSet<Matricula>();
        }

        public int IdEstudiante { get; set; }
        public string NombreEstudiante { get; set; } = null!;
        public int EdadEstudiante { get; set; }
        public string SexoEstudiante { get; set; } = null!;

        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
