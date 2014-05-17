using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBlog.Models;
using WebBlog.DAL;

namespace WebBlog.Controllers
{
    public class AutorController : Controller
    {
        private DbContexto db = new DbContexto();

        // GET: /Autor/
        
        public ActionResult Index()
        {
            if (Session["Logado"] == null) {
                return RedirectToAction("Login", "Home"); 
            }
            else
            {
                return View(db.Autores.ToList());
            }
            
        }

        // GET: /Autor/Details/5
        
        public ActionResult Details(int? id)
        {
            if (Session["Logado"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Autor autor = db.Autores.Find(id);
                if (autor == null)
                {
                    return HttpNotFound();
                }
                return View(autor);
            }
        }

        // GET: /Autor/Create
        
        public ActionResult Create()
        {
            if (Session["Logado"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                return View();
            }
        }

        // POST: /Autor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Create([Bind(Include="AutorId,Nome,Formacao,Email,Senha")] Autor autor)
        {
            if (Session["Logado"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    EncodePassword enc = new EncodePassword();
                    autor.Senha = enc.EncodePass(autor.Senha);
                    db.Autores.Add(autor);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(autor);
            }
        }

        // GET: /Autor/Edit/5
        
        public ActionResult Edit(int? id)
        {
            if (Session["Logado"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Autor autor = db.Autores.Find(id);
                if (autor == null)
                {
                    return HttpNotFound();
                }
                return View(autor);
            }
        }

        // POST: /Autor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Edit([Bind(Include="AutorId,Nome,Formacao,Email,Senha")] Autor autor)
        {
            if (Session["Logado"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Entry(autor).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(autor);
            }
        }

        // GET: /Autor/Delete/5
        
        public ActionResult Delete(int? id)
        {
            if (Session["Logado"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Autor autor = db.Autores.Find(id);
                if (autor == null)
                {
                    return HttpNotFound();
                }
                return View(autor);
            }
        }

        // POST: /Autor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["Logado"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                Autor autor = db.Autores.Find(id);
                db.Autores.Remove(autor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
