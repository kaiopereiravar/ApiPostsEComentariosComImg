using DesafioVarBancoRepository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioVarBancoRepository
{
    public class DesafioVarBancoContext : DbContext
    {
        public DesafioVarBancoContext(DbContextOptions<DesafioVarBancoContext> options) : base(options) { }

        public DbSet<TabSaldo> tabSaldo { get; set; }

        public DbSet<TabPessoa> tabPessoa { get; set; }

        public DbSet<TabHistoricoCompras> TabHistoricoCompras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TabSaldo>().ToTable("TabSaldo");

            modelBuilder.Entity<TabHistoricoCompras>().ToTable("TabHistoricoCompras");

            modelBuilder.Entity<TabPessoa>().ToTable("TabPessoa");
        }
    }
}
