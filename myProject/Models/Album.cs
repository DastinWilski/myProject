using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace myProject.Models
{
    
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }
        

        public virtual ICollection<myFile> myFiles { get;set; }
    }
}