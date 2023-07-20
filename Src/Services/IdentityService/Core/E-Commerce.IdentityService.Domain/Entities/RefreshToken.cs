using E_Commerce.IdentityService.Domain.Entities.Identity;

namespace E_Commerce.IdentityService.Domain.Entities
{
    public class RefreshToken : IEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public required string Token { get; set; }
        public DateTime Expires { get; set; }
        public string? CreatedByIp { get; set; }
        public required AppUser User { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
