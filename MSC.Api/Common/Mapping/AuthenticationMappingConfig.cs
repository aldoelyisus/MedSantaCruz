using Mapster;

using MSC.Application.Authentication.Commands.Register;
using MSC.Application.Authentication.Common;
using MSC.Application.Authentication.Queries.Login;
using MSC.Contracts.Authentication;

namespace MSC.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Id, src => src.User.Id.Value)
            .Map(dest => dest, src => src.User)
            .Map(dest => dest.Token, src => src.Token);
    }
}