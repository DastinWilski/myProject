using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace myProject.Models
{
    
    public class Playlist
    {
        [Key]
        public int PlaylistId { get; set; }

        public string PlaylistName { get; set; }

        


        public virtual ICollection<myFile> myFiles { get; set; }
    }
}