using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace myProject.Models
{
   
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }

        public string Name { get; set; }

        


        public virtual ICollection<myFile> myFiles { get; set; }
    }
}