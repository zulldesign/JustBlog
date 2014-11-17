using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JustBlog.Models;

namespace JustBlog.Controllers
{ 
    public class BlogController : Controller
    {
        private dbc1d58df3021849f5a187a3e60050cbcaEntities db = new dbc1d58df3021849f5a187a3e60050cbcaEntities();

        //
        // GET: /Blog/

        public ViewResult Index()
        {
            return View(db.Blogs.ToList());
        }

        //
        // GET: /Blog/Details/5

        public ViewResult Details(int id)
        {
            Blogs blogs = db.Blogs.Find(id);
            return View(blogs);
        }

        //
        // GET: /Blog/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Blog/Create

        [HttpPost]
        public ActionResult Create(Blogs blogs)
        {
            if (ModelState.IsValid)
            {
                db.Blogs.Add(blogs);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(blogs);
        }
        
        //
        // GET: /Blog/Edit/5
 
        public ActionResult Edit(int id)
        {
            Blogs blogs = db.Blogs.Find(id);
            return View(blogs);
        }

        //
        // POST: /Blog/Edit/5

        [HttpPost]
        public ActionResult Edit(Blogs blogs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogs);
        }

        //
        // GET: /Blog/Delete/5
 
        public ActionResult Delete(int id)
        {
            Blogs blogs = db.Blogs.Find(id);
            return View(blogs);
        }

        //
        // POST: /Blog/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Blogs blogs = db.Blogs.Find(id);
            db.Blogs.Remove(blogs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}