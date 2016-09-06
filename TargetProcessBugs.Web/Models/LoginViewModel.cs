
using System.ComponentModel.DataAnnotations;

namespace TargetProcessBugs.Web.Models
{
    public class LoginViewModel
    {
        [Display(Name ="Username")]
        [Required(ErrorMessage = "Required")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Required")]
        public string Password { get; set; }
    }
}