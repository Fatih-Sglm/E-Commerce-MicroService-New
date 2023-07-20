using AutoMapper;
using E_Commerce.IdentityService.Application.Features.AppUsers.Command.CreateUser;
using E_Commerce.IdentityService.Domain.Entities.Identity;

namespace E_Commerce.IdentityService.Application.Features.Auth.Profiles
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<CreateUserCommand, AppUser>();
        }
    }
}
