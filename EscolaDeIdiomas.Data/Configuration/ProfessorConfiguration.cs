using System;
using System.Collections.Generic;
using System.Text;
using EscolaDeIdiomas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaDeIdiomas.Data.Configuration
{
    public class ProfessorConfiguration : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.ToTable("Professores");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.CPF)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(x => x.Telefone)
                .IsRequired()
                .HasMaxLength(15);
        }
    }
}
