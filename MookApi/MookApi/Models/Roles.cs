using Microsoft.AspNetCore.Identity;

namespace MookApi.Models
{
    public class Roles :IdentityRole<long>
    {
        public Boolean isDeleted { get; set; }
    }
}
