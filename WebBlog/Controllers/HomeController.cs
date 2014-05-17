using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBlog.DAL;
using WebBlog.Models;

namespace WebBlog.Controllers
{
    public class HomeController : Controller
    {
        private DbContexto db = new DbContexto();

        public ActionResult Post(int PostId)
        {
            var Pagina = db.Posts.FirstOrDefault(p => p.PostId == PostId);
            return View(Pagina);
        }

        public ActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (model != null)
            {
                EncodePassword enc = new EncodePassword();
                string senha = enc.EncodePass(model.Senha);
                Autor aut = db.Autores.FirstOrDefault(p => p.Email == model.Login && p.Senha == senha);
                // Autor autor = db.Autores.Find(model.Login, model.Senha);
                //aut = db.Autores.Find(autor => autor.).;
                Session["Logado"] = aut;
                if (aut == null)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult LogOut()
        {
            Session["Logado"] = null;
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var query = from e in db.Posts 
                        select e;
            var post = query.ToList();
            return View(db.Posts.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}