using Microsoft.AspNetCore.Identity;

namespace MookApi.Models
{
    public class Users : IdentityUser<long>
    {
        public string createdDate { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; }

        public Admins admins { get; set; }
        public Students students { get; set; }
    }
}
