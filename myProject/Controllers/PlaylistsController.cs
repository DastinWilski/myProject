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
using myProject.ViewModels;

namespace myProject.Controllers
{
    public class PlaylistsController : Controller
    {
        private myContext db = new myContext();

        // GET: Playlists
        public ActionResult Index()
        {
            return View(db.Playlists.ToList());
        }

        // GET: Playlists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Playlist playlist = db.Playlists.Find(id);
            if (playlist == null)
            {
                return HttpNotFound();
            }
            var Results = from b in db.myFiles
                          select new
                          {
                              b.FileId,
                              b.FileName,
                              Checked = ((from ab in db.FilesToPlaylists where (ab.PlaylistID == id) & (ab.FileID == b.FileId) select ab).Count() > 0)

                          };
            var MyViewModel = new PlaylistViewModel();
            MyViewModel.PlaylistId = id.Value;
            MyViewModel.PlaylistName = playlist.PlaylistName;
            var MyCheckBoxList = new List<CheckBoxViewModel>();
            foreach (var item in Results)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel { Id = item.FileId, Name = item.FileName, Checked = item.Checked });
            }
            MyViewModel.myFiles = MyCheckBoxList;
            return View(MyViewModel);
        }

        // GET: Playlists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Playlists/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlaylistId,PlaylistName")] Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                db.Playlists.Add(playlist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(playlist);
        }

        // GET: Playlists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Playlist playlist = db.Playlists.Find(id);
            if (playlist == null)
            {
                return HttpNotFound();
            }
            var Results = from b in db.myFiles
                          select new
                          {
                              b.FileId,
                              b.FileName,
                              Checked = ((from ab in db.FilesToPlaylists where (ab.PlaylistID == id) & (ab.FileID == b.FileId)select ab).Count() > 0)
                              
                          };
            var MyViewModel = new PlaylistViewModel();
            MyViewModel.PlaylistId = id.Value;
            MyViewModel.PlaylistName = playlist.PlaylistName;
            var MyCheckBoxList = new List<CheckBoxViewModel>();
            foreach (var item in Results)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel { Id = item.FileId, Name = item.FileName, Checked = item.Checked });
            }
            MyViewModel.myFiles = MyCheckBoxList;
            return View(MyViewModel);
        }

        // POST: Playlists/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PlaylistViewModel playlist)
        {
            if (ModelState.IsValid)
            {
                var MyPlaylist = db.Playlists.Find(playlist.PlaylistId);
                MyPlaylist.PlaylistName = playlist.PlaylistName;

                foreach(var item in db.FilesToPlaylists)
                {
                    if(item.PlaylistID == playlist.PlaylistId)
                    {
                        db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    }
                }
                foreach (var item in playlist.myFiles)
                {
                    if (item.Checked)
                    {
                        db.FilesToPlaylists.Add(new FilesToPlaylist() { PlaylistID = playlist.PlaylistId, FileID = item.Id });
                    }
                    
                }

                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(playlist);
        }

        // GET: Playlists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Playlist playlist = db.Playlists.Find(id);
            if (playlist == null)
            {
                return HttpNotFound();
            }
            return View(playlist);
        }

        // POST: Playlists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Playlist playlist = db.Playlists.Find(id);
            db.Playlists.Remove(playlist);
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
