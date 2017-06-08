using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModel
{
    public class CreateViewModel :IValidatableObject
    {
        [Required]
        [DisplayName("Choisis un pseudo :")]
        public string Pseudo { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [DisplayName("Ton mail :")]
        public string Email { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Ton mot de passe doit contenir au moins {0} caractères", MinimumLength = 6)]
        [DisplayName("Un mot de passe :")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DisplayName("Entre ton mot de passe à nouveau :")]
        [DataType(DataType.Password)]
        public string VerifPassword { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Password != VerifPassword)
            {
                yield return new  ValidationResult("Les mots de passe ne semblent pas identiques...", new[] { "Password", "VerifPassword" });
            }
        }
    }
}