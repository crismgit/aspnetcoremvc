using System;
using System.Collections.Generic;
using System.Text;
using EscolaDeIdiomas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaDeIdiomas.Data.Configuration
{
    public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Alunos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.RG)
                .HasMaxLength(20);

            builder.Property(x => x.Telefone)
                .IsRequired()
                .HasMaxLength(15);
        }
    }
}
