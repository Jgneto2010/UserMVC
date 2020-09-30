using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Mappings
{
    public class ClientMapping : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(e => e.Id)
                   .HasColumnName("Id_Client")
                   .HasColumnType("varchar(40)")
                   .IsRequired();

            builder.Property(e => e.Name)
                   .HasColumnName("Name_Client")
                   .HasColumnType("varchar(40)")
                   .IsRequired();

            builder.Property(e => e.Email)
                 .HasColumnName("Email")
                 .HasColumnType("varchar(40)")
                 .IsRequired();

            builder.Property(e => e.Cpf)
                 .HasColumnName("CPF")
                 .HasColumnType("varchar(11)")
                 .IsRequired();
        }
    }
}
