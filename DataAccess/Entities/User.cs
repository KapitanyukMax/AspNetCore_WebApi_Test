using Microsoft.AspNetCore.Identity;

namespace DataAccess.Entities
{
    public class User : IdentityUser
    {
        public DateTime Birthdate { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
