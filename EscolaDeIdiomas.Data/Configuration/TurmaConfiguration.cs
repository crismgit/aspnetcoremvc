using System;
using System.Collections.Generic;
using System.Text;
using EscolaDeIdiomas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaDeIdiomas.Data.Configuration
{
    public class TurmaConfiguration : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.ToTable("Turmas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Descricao)
                .HasMaxLength(300);

            builder.Property(x => x.Idioma)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(x => x.Nivel)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.Periodo)
                .IsRequired()
                .HasMaxLength(30);

            builder
                .HasOne(x => x.Professor)
                .WithMany(p => p.Turmas)
                .HasForeignKey(x => x.ProfessorId);
        }
    }
}
