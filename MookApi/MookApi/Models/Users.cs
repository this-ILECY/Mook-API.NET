using Microsoft.AspNetCore.Identity;

namespace MookApi.Models
{
    public class Users : IdentityUser<long>
    {
        //public int UserID { get; set; }
        public string CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public Admins Admins { get; set; }
        public Students students { get; set; }
    }
}
