using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModel
{
    public class UserViewModel : IValidatableObject
    {
        public string Pseudo;

        [EmailAddress(ErrorMessage = "Votre mail n'est pas valide")]
        public string Mail; 

        public string Nom;

        public string Prenom;

        public string Adresse;

        public string CodePostale;

        public string Ville;

        public string Password;

        public string VerifPassword;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Password != VerifPassword)
                yield return new ValidationResult("Mot de passe non identique...", new[] {"Password", "VerifPassword" });
        }
    }
}