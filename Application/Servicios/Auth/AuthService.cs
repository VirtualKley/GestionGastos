using Application.Interfaces.Auth;
using Domain.DTOs.Auth;
using Domain.Request.Auth;

namespace Application.Servicios.Auth;

public class AuthService : IAuthService
{
    public Task<AuthResponseDto> LoginAsync(LoginRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<AuthResponseDto> RegisterAsync(RegisterRequest request)
    {
        throw new NotImplementedException();
    }
}