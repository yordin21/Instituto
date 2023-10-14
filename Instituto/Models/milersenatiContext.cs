using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Instituto.Models
{
    public partial class milersenatiContext : DbContext
    {
        public milersenatiContext()
        {
        }

        public milersenatiContext(DbContextOptions<milersenatiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bloque> Bloques { get; set; } = null!;
        public virtual DbSet<BloqueDetalle> BloqueDetalles { get; set; } = null!;
        public virtual DbSet<Curso> Cursos { get; set; } = null!;
        public virtual DbSet<Estudiante> Estudiantes { get; set; } = null!;
        public virtual DbSet<Matricula> Matriculas { get; set; } = null!;
        public virtual DbSet<Profesore> Profesores { get; set; } = null!;
        public virtual DbSet<Programa> Programas { get; set; } = null!;

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //                optionsBuilder.UseSqlServer("server=milersenati.database.windows.net; database=abrahamsenati; User ID=Miler; Password=Yordin@21;");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bloque>(entity =>
            {
                entity.HasKey(e => e.IdBloque)
                    .HasName("PK__Bloques__6B063943F255F3F1");

                entity.Property(e => e.IdBloque)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Bloque");

                entity.Property(e => e.NombreBloque)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Bloque");

                entity.Property(e => e.PeriodoBloque)
                    .HasColumnType("date")
                    .HasColumnName("Periodo_Bloque");
            });

            modelBuilder.Entity<BloqueDetalle>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BloqueDetalle");

                entity.Property(e => e.IdBloque).HasColumnName("ID_Bloque");

                entity.Property(e => e.IdCurso).HasColumnName("ID_Curso");

                entity.Property(e => e.IdProfesor).HasColumnName("ID_Profesor");

                entity.Property(e => e.IdPrograma).HasColumnName("ID_Programa");

                entity.HasOne(d => d.IdBloqueNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdBloque)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BloqueDet__ID_Bl__656C112C");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BloqueDet__ID_Cu__6754599E");

                entity.HasOne(d => d.IdProfesorNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdProfesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BloqueDet__ID_Pr__68487DD7");

                entity.HasOne(d => d.IdProgramaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPrograma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BloqueDet__ID_Pr__66603565");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__Cursos__DC72196FC137B482");

                entity.Property(e => e.IdCurso)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Curso");

                entity.Property(e => e.DescripciónCurso)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Descripción_Curso");

                entity.Property(e => e.DuraciónCurso).HasColumnName("Duración_Curso");

                entity.Property(e => e.NombreCurso)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Curso");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.IdEstudiante)
                    .HasName("PK__Estudian__9B410A89B7FE9618");

                entity.Property(e => e.IdEstudiante)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Estudiante");

                entity.Property(e => e.EdadEstudiante).HasColumnName("Edad_Estudiante");

                entity.Property(e => e.NombreEstudiante)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Estudiante");

                entity.Property(e => e.SexoEstudiante)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Sexo_Estudiante");
            });

            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.HasKey(e => e.IdMatricula)
                    .HasName("PK__Matricul__230086D7F2DBF9EF");

                entity.Property(e => e.IdMatricula)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Matricula");

                entity.Property(e => e.IdBloque).HasColumnName("ID_Bloque");

                entity.Property(e => e.IdEstudiante).HasColumnName("ID_Estudiante");

                entity.Property(e => e.PeriodoMatricula)
                    .HasColumnType("date")
                    .HasColumnName("Periodo_Matricula");

                entity.HasOne(d => d.IdBloqueNavigation)
                    .WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.IdBloque)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Matricula__ID_Bl__6C190EBB");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.IdEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Matricula__ID_Es__6B24EA82");
            });

            modelBuilder.Entity<Profesore>(entity =>
            {
                entity.HasKey(e => e.IdProfesor)
                    .HasName("PK__Profesor__4D3751F66E5BADF9");

                entity.Property(e => e.IdProfesor)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Profesor");

                entity.Property(e => e.EspecialidadProfesor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Especialidad_Profesor");

                entity.Property(e => e.NombreProfesor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Profesor");
            });

            modelBuilder.Entity<Programa>(entity =>
            {
                entity.HasKey(e => e.IdPrograma)
                    .HasName("PK__Programa__9DB8D163B41C8E84");

                entity.Property(e => e.IdPrograma)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Programa");

                entity.Property(e => e.DuraciónPrograma).HasColumnName("Duración_Programa");

                entity.Property(e => e.NombrePrograma)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Programa");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
