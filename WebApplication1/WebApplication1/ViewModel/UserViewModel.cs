using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModel
{
    public class UserViewModel : IValidatableObject
    {
        [DisplayName("Pseudonyme :")]
        public string Pseudo { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [DisplayName("Email  :")]
        public string Mail { get; set; }

        [DisplayName("Ton nom de famille :")]
        public string Nom { get; set; }

        [DisplayName("Ton prénom :")]
        public string Prenom { get; set; }

        [DisplayName("Ton adresse :")]
        public string Adresse { get; set; }

        [DisplayName("Votre adresse :")]
        public string CodePostale { get; set; }

        [DisplayName("Dans quelle ville habites-tu ?")]
        public string Ville { get; set; }

        [DisplayName("Saisis un nouveau mot de passe :")]
        [Required]
        public string Password { get; set; }

        [DisplayName("Saisis à nouveau le mot de passe :")]
        [Required]
        public string VerifPassword { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Password != VerifPassword)
                yield return new ValidationResult("Mot de passe non identique...", new[] {"Password", "VerifPassword" });
        }
    }
}