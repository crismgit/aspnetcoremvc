using System;
using System.Collections.Generic;
using System.Text;
using EscolaDeIdiomas.Domain;
using EscolaDeIdiomas.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace EscolaDeIdiomas.Data
{
    public class EscolaDeIdiomasContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<AlunoTurma> AlunoTurmas { get; set; }

        public EscolaDeIdiomasContext(DbContextOptions<EscolaDeIdiomasContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessorConfiguration());
            modelBuilder.ApplyConfiguration(new TurmaConfiguration());
            modelBuilder.ApplyConfiguration(new AlunoTurmaConfiguration());
        }
    }
}
