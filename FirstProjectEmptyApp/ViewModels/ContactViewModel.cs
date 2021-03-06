using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProjectEmptyApp.ViewModels
{
    public class ContactViewModel
    {

        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        [MaxLength(250)]
        public string Message { get; set; }
    }
}
