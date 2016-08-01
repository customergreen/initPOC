using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CustomerGreen.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);

            return userIdentity;
        }

        public ApplicationUser()
        {
            DateCreated = DateTime.Now;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public bool Activated { get; set; }
        public long OrgId { get; set; }
    }

    public class ApplicationRole : IdentityRole
    {
        public long OrgId { get; set; }
        public string DisplayName { get; set; }
        public ApplicationRole() : base() { }
        public ApplicationRole(string name, long orgId, string displayName)
            : base(name)
        {
            this.OrgId = orgId;
            this.DisplayName = displayName;
        }
    }
}
