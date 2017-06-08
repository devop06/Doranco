using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.Entity;

namespace WebApplication1
{
    public  static class UserData
    {

        public static List<Models.Entity.User> ListUser = new List<User>()
        {
             new User()
                {
                  id = 1,
                pseudo = "toto",
                password = "test",
                mail = "test@gmail.com",
                ville = "Paris",
                adresse = "4 rue de tata",
                codePostale = "75012",
                nom = "nom",
                prenom = "prenom"
                }
        };

        public static List<Models.Entity.User> GetLesUtilisateurs()
        {
            return ListUser;
         }

    }
}