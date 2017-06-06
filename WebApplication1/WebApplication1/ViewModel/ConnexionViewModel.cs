using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModel
{
    public class ConnexionViewModel
    {
        [Required]
        public String Identifiant { get; set; }
        [Required]
        public String Password { get; set; }
    }
}