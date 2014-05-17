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
    
    public class ComentarioController : Controller
    {
        private DbContexto db = new DbContexto();

        // GET: /Comentario/
        public ActionResult Index()
        {
            if (Session["Logado"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var comentarios = db.Comentarios.Include(c => c.Post);
                return View(comentarios.ToList());
            }
        }

        // GET: /Comentario/Details/5
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
                Comentario comentario = db.Comentarios.Find(id);
                if (comentario == null)
                {
                    return HttpNotFound();
                }
                return View(comentario);
            }
        }

        // GET: /Comentario/Create
        public ActionResult Create()
        {
            if (Session["Logado"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                ViewBag.PostId = new SelectList(db.Posts, "PostId", "Titulo");
                return View();
            }
        }

        // POST: /Comentario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ComentarioId,PostId,dataComentario,Autor,comenatrio")] Comentario comentario)
        {
            if (Session["Logado"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Comentarios.Add(comentario);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.PostId = new SelectList(db.Posts, "PostId", "Titulo", comentario.PostId);
                return View(comentario);
            }
        }

        // GET: /Comentario/Edit/5
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
                Comentario comentario = db.Comentarios.Find(id);
                if (comentario == null)
                {
                    return HttpNotFound();
                }
                ViewBag.PostId = new SelectList(db.Posts, "PostId", "Titulo", comentario.PostId);
                return View(comentario);
            }
        }

        // POST: /Comentario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ComentarioId,PostId,dataComentario,Autor,comenatrio")] Comentario comentario)
        {
            if (Session["Logado"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Entry(comentario).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.PostId = new SelectList(db.Posts, "PostId", "Titulo", comentario.PostId);
                return View(comentario);
            }
        }

        // GET: /Comentario/Delete/5
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
                Comentario comentario = db.Comentarios.Find(id);
                if (comentario == null)
                {
                    return HttpNotFound();
                }
                return View(comentario);
            }
        }

        // POST: /Comentario/Delete/5
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
                Comentario comentario = db.Comentarios.Find(id);
                db.Comentarios.Remove(comentario);
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
