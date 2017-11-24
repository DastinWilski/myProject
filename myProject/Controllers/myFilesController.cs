using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using myProject.DAL;
using myProject.Models;

namespace myProject.Controllers
{
    public class myFilesController : Controller
    {
        private myContext db = new myContext();

        // GET: myFiles
        public ActionResult Index()
        {
            var myFiles = db.myFiles.Include(m => m.Album).Include(m => m.Genre).Include(m => m.myType);
            return View(myFiles.ToList());
        }

        // GET: myFiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            myFile myFile = db.myFiles.Find(id);
            if (myFile == null)
            {
                return HttpNotFound();
            }
            return View(myFile);
        }

        // GET: myFiles/Create
        public ActionResult Create()
        {
            ViewBag.AlbumID = new SelectList(db.Albums, "AlbumId", "Name");
            ViewBag.GenreID = new SelectList(db.Genres, "GenreId", "Name");
            ViewBag.myTypeID = new SelectList(db.myTypes, "myTypeId", "Name");
            return View();
        }

        // POST: myFiles/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FileId,Name,Path,Created,AlbumID,GenreID,myTypeID")] myFile myFile)
        {
            if (ModelState.IsValid)
            {
                db.myFiles.Add(myFile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlbumID = new SelectList(db.Albums, "AlbumId", "Name", myFile.AlbumID);
            ViewBag.GenreID = new SelectList(db.Genres, "GenreId", "Name", myFile.GenreID);
            ViewBag.myTypeID = new SelectList(db.myTypes, "myTypeId", "Name", myFile.myTypeID);
            return View(myFile);
        }

        // GET: myFiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            myFile myFile = db.myFiles.Find(id);
            if (myFile == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlbumID = new SelectList(db.Albums, "AlbumId", "Name", myFile.AlbumID);
            ViewBag.GenreID = new SelectList(db.Genres, "GenreId", "Name", myFile.GenreID);
            ViewBag.myTypeID = new SelectList(db.myTypes, "myTypeId", "Name", myFile.myTypeID);
            return View(myFile);
        }

        // POST: myFiles/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FileId,Name,Path,Created,AlbumID,GenreID,myTypeID")] myFile myFile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myFile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlbumID = new SelectList(db.Albums, "AlbumId", "Name", myFile.AlbumID);
            ViewBag.GenreID = new SelectList(db.Genres, "GenreId", "Name", myFile.GenreID);
            ViewBag.myTypeID = new SelectList(db.myTypes, "myTypeId", "Name", myFile.myTypeID);
            return View(myFile);
        }

        // GET: myFiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            myFile myFile = db.myFiles.Find(id);
            if (myFile == null)
            {
                return HttpNotFound();
            }
            return View(myFile);
        }

        // POST: myFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            myFile myFile = db.myFiles.Find(id);
            db.myFiles.Remove(myFile);
            db.SaveChanges();
            return RedirectToAction("Index");
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
