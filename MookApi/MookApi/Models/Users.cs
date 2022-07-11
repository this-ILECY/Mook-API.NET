using Microsoft.AspNetCore.Identity;

namespace MookApi.Models
{
    public class Users : IdentityUser<long>
    {
        public string CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public Admins Admins { get; set; }
        public Students Students { get; set; }
    }
}
