using CleanArchExample.Application.Users.CreateUser;
using AutoMapper;
using CleanArchExample.WebApi.Features.Users.CreateUser;

namespace CleanArchExample.WebApi.Mappings;

public class CreateUserRequestProfile : Profile
{
    public CreateUserRequestProfile()
    {
        CreateMap<CreateUserRequest, CreateUserCommand>();
    }
}