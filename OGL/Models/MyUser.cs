using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OGL.Models
{
    public class MyUser : IdentityUser
    {
           public MyUser()
        {
            this.Ogloszenia = new HashSet<MyAd>();

        }

        public int? Wiek { get; set; }
        public string Pseudonim { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        #region dodatkowe pole notmapped
        [NotMapped]
        [Display(Name = "Pan/Pani: ")]
        public string PelneNazwisko
        {
            get { return Imie + " " + Nazwisko; }

        }
        #endregion

        public virtual ICollection<MyAd> Ogloszenia { get; private set; }
       


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<MyUser> manager)
            {
                // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
                var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
                // Add custom user claims here
                return userIdentity;
            }
        
    }
}