using Ambev.DeveloperEvaluation.Application.Auth.AuthenticateUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Auth.AuthenticateUserFeature;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<AuthenticateUserRequest, AuthenticateUserCommand>();
            CreateMap<AuthenticateUserResult, AuthenticateUserResponse>();
        }
    }
}
