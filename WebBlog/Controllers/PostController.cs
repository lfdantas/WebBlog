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
    public class PostController : Controller
    {
        private DbContexto db = new DbContexto();

        // GET: /Post/
        
        public ActionResult Index()
        {
            if (Session["Logado"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var posts = db.Posts.Include(p => p.Autor);
                return View(posts.ToList());
            }
        }

        // GET: /Post/Details/5
        
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
                Post post = db.Posts.Find(id);
                if (post == null)
                {
                    return HttpNotFound();
                }
                return View(post);
            }
        }

        // GET: /Post/Create
        
        public ActionResult Create()
        {
            if (Session["Logado"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                ViewBag.AutorId = new SelectList(db.Autores, "AutorId", "Nome");
                return View();
            }
        }

        // POST: /Post/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Create([Bind(Include="PostId,AutorId,Titulo,Conteudo")] Post post)
        {
            if (Session["Logado"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Posts.Add(post);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.AutorId = new SelectList(db.Autores, "AutorId", "Nome", post.AutorId);
                return View(post);
            }
        }

        // GET: /Post/Edit/5
        
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
                Post post = db.Posts.Find(id);
                if (post == null)
                {
                    return HttpNotFound();
                }
                ViewBag.AutorId = new SelectList(db.Autores, "AutorId", "Nome", post.AutorId);
                return View(post);
            }
        }

        // POST: /Post/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Edit([Bind(Include="PostId,AutorId,Titulo,Conteudo")] Post post)
        {
            if (Session["Logado"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Entry(post).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.AutorId = new SelectList(db.Autores, "AutorId", "Nome", post.AutorId);
                return View(post);
            }
        }

        // GET: /Post/Delete/5
        
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
                Post post = db.Posts.Find(id);
                if (post == null)
                {
                    return HttpNotFound();
                }
                return View(post);
            }
        }
        
        // POST: /Post/Delete/5
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
                Post post = db.Posts.Find(id);
                db.Posts.Remove(post);
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
