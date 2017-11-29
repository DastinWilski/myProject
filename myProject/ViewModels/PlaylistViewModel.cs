using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myProject.ViewModels
{
    public class PlaylistViewModel
    {
        public int PlaylistId { get; set; }
        public string PlaylistName { get; set; }
        public List<CheckBoxViewModel> myFiles { get; set; }
    }
}