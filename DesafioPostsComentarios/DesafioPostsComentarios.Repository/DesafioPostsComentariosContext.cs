using DesafioPostsComentarios.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace DesafioPostsComentarios.Repository
{
    public class DesafioPostsComentariosContext : DbContext
    {
        public DesafioPostsComentariosContext(DbContextOptions<DesafioPostsComentariosContext> options) : base(options) { }

        public DbSet<TabPosts> TabPosts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TabPosts>().ToTable("TabPosts");
        }
    }
}
