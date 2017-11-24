using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace myProject.Models
{
    
    public class myType
    {
        [Key]
        public int myTypeId { get; set; }

        public string TypeName { get; set; }




        public virtual ICollection<myFile> myFiles { get; set; }
    }
}