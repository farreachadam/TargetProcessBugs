using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TargetProcessBugs.Web.Models
{
    public class ApiPocViewModel
    {
        [Display(Name = "Project")]
        public int SelectedProjectId { get; set; }
        public List<SelectListItem> Projects { get; set; }        
    }
}