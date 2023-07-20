using Microsoft.AspNetCore.Identity;

namespace E_Commerce.IdentityService.Domain.Entities.Identity
{
    public class AppRole : IdentityRole<Guid>, IEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
