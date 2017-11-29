using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myProject.Models
{
    public class FilesToPlaylist
    {
        public int FilesToPlaylistID { get; set; }
        public int FileID { get; set; }
        public int PlaylistID { get; set; }

        public virtual myFile myFile { get; set; }
        public virtual Playlist Playlist { get; set; }
    }
}