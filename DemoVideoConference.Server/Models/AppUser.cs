using Microsoft.AspNetCore.Identity;

namespace DemoVideoConference.Server.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set;} = string.Empty;
    }
}
