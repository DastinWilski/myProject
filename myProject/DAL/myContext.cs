using myProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace myProject.DAL
{
    public class myContext:DbContext
    {
        public myContext() : base("myConnectionString")
        { }
        public DbSet<myFile> myFiles { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<myType> myTypes { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
    }
}