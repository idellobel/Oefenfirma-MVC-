using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Ivo.OefenfirmaCMS.lib.Data;
using Ivo.OefenfirmaCMS.lib.Entities;
using System.Web.Security;

namespace Ivo.OefenfirmaCMS.lib.Services
{
    public class UserService
    {
        private IvoOefenfirmaContext context;
        private SHA512CryptoServiceProvider crypto;

        public UserService()
        {
            context = new IvoOefenfirmaContext();
            crypto = new SHA512CryptoServiceProvider();
        }


        public User GetUserById(long id)
        {


            return context.Set<User>()
                .Find(id)
               ;
            
        }

        public ICollection<User> GetAllUsersWithRoles()
        {
            return context.User
                .Include("Roles")
                .OrderBy(u => u.Gebruikersnaam)
                .ToList();
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);    //wachtwoord naar bytes
            byte[] hashBytes = crypto.ComputeHash(passwordBytes);       //hashen
            string hashString = Encoding.UTF8.GetString(hashBytes);  //hash naar string

            User user = context.User
                .Include("Roles")
                .Where(u => u.Gebruikersnaam.ToUpper() == username.ToUpper() &&
                            u.PaswoordHash == hashString)
                .FirstOrDefault();
            return user;
        }

        public bool CheckCredentials(string username, string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);    //wachtwoord naar bytes
            byte[] hashBytes = crypto.ComputeHash(passwordBytes);       //hashen
            string hashString = Encoding.UTF8.GetString(hashBytes);     //hash naar string
            //bestaat er een gebruiker met deze username + paswoord combinatie

            bool canLogin = context.Set<User>()
                .Include("Roles")
                .Any(e =>
                    e.Gebruikersnaam.ToUpper() == username.ToUpper() &&
                    e.PaswoordHash == hashString
                )
              ;
            return canLogin;
        }
    }
}
    
