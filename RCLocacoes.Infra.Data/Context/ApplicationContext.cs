using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RCLocacoes.Domain.Entities;
using RCLocacoes.Infra.Data.Entity.AddressMap;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RCLocacoes.Infra.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MapEntity(modelBuilder);
            DesableDeleteCascade(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void MapEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void DesableDeleteCascade(ModelBuilder modelBuilder)
        {
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }

}
