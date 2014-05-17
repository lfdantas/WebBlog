using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebBlog.DAL;
using WebBlog.Models;

namespace WebBlog
{
    class PopuladorBaseDados : DropCreateDatabaseIfModelChanges<DbContexto>
    {
        protected override void Seed(DbContexto context)
        {
            base.Seed(context);

            //Adicionar carga de dados inicial
            Autor autor = new Autor
            {
                Nome = "Luiz Felipe Marinho Dantas",
                Formacao = "Unibratec",
                Email = "luizfelipemarinho@live.com",
                Senha = "a6c184e8ffae2038c758d938bae605b6"
            };
            context.Autores.Add(autor);

            autor = new Autor
            {
                Nome = "Paulo Sergio Pereira",
                Formacao = "UNICAMP",
                Email = "p.sergio@terra.com.br",
                Senha = "a6c184e8ffae2038c758d938bae605b6"
            };
            context.Autores.Add(autor);

            context.SaveChanges();
        }
    }
}