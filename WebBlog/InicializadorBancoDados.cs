using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebBlog.DAL;

namespace WebBlog
{
    /// <summary>
    /// Classe responsável por criar/inicializar o banco de dados
    /// </summary>
    public class InicializadorBancoDados
    {
        public static void Inicializar()
        {
            Database.SetInitializer(new PopuladorBaseDados()); //Passando o inicializador do banco de dados
            //Força a criação do banco de dados
            using (DbContexto context = new DbContexto())
                context.Database.Initialize(force: true);
        }
    }
}