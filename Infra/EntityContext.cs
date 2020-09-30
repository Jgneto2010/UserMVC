using Domain.Entities;
using Infra.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra
{
    public class EntityContext : DbContext
    {
        public EntityContext()
        {

        }
        public EntityContext(DbContextOptions<EntityContext> options) : base(options) { }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=DESKTOP-03T36MT\\SQLEXPRESS; Database = DesafioMvc; Trusted_Connection=True;");
            base.OnConfiguring(builder);
        }


    }
}
