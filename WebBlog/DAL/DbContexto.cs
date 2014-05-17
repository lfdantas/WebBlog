using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebBlog.Models;

namespace WebBlog.DAL
{
    public class DbContexto : DbContext
    {
        public DbContexto() : base("DBWebBlog") { }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
    }
}