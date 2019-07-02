using System;
using System.Collections.Generic;
using System.Text;
using EscolaDeIdiomas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaDeIdiomas.Data.Configuration
{
    public class AlunoTurmaConfiguration : IEntityTypeConfiguration<AlunoTurma>
    {
        public void Configure(EntityTypeBuilder<AlunoTurma> builder)
        {
            builder.ToTable("AlunosTurmas");

            builder.HasKey(x => new { x.AlunoId, x.TurmaId });

            builder
                .HasOne(x => x.Aluno)
                .WithMany(p => p.AlunoTurmas)
                .HasForeignKey(x => x.AlunoId);

            builder
                .HasOne(x => x.Turma)
                .WithMany(p => p.AlunoTurmas)
                .HasForeignKey(x => x.TurmaId);
        }
    }
}
