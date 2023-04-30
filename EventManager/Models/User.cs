using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EventManager.Models
{
    public class User : IdentityUser
    {

        public string firstName { get; set; }
        public string lastName { get; set; }

    }
}
