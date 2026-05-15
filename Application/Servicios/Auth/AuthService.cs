using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Interfaces.Auth;
using Domain.Configuraciones;
using Domain.DTOs.Auth;
using Domain.Entidades.Auth;
using Domain.Enumeraciones;
using Domain.Repositorios.Base;
using Domain.Request.Auth;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Application.Servicios.Auth;

public class AuthService(
    IUsuarioRepositorio usuarioRepositorio, 
    IOptions<JwtSettings> jwtSettings) : IAuthService
{
    private readonly IUsuarioRepositorio _usuarioRepositorio = usuarioRepositorio;
    private readonly JwtSettings _jwtSettings = jwtSettings.Value;

    public async Task<AuthResponseDto> LoginAsync(LoginRequest request)
    {
        //1. Verificar que el email exista
        var usuario = await _usuarioRepositorio.ObtenerPorEmailAsync(request.Email)
            ?? throw new UnauthorizedAccessException("Credenciales Invalidas");

        //2. Verificar que el usaurio este activo
        if (!usuario.Activo)
            throw new UnauthorizedAccessException("Usuario Deshabilitado");

        //3. Verificar la contraseña
        if (!BCrypt.Net.BCrypt.Verify(request.Password, usuario.PasswordHash))
            throw new UnauthorizedAccessException("Credenciales Invalidas");

        //4. Generar y retornar token
        return GenerarToken(usuario);
    }

    public async Task<AuthResponseDto> RegisterAsync(RegisterRequest request)
    {
        //1. Verificar que el email no exista
        if (await _usuarioRepositorio.ExisteEmailAsync(request.Email))
            throw new InvalidOperationException("El email ya se encuentra registrado");

        //2. Crear la entidad usuario
        var usuario = new Usuario
        {
            Nombre = request.Nombre,
            Email = request.Email,
            Rol = RolUsuario.User,
            FechaCreacion = DateTime.UtcNow,
            Activo = true,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password, workFactor: 11),
        };

        //3. Guardar en base de datos
        await _usuarioRepositorio.AgregarAsync(usuario);

        //4. Generar el token
        return GenerarToken(usuario);
    }

    private AuthResponseDto GenerarToken(Usuario usuario)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("role", usuario.Rol.ToString())
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_jwtSettings.Key)
        );

        var credentials = new SigningCredentials(
            key, SecurityAlgorithms.HmacSha256
        );

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationMinutes),
            signingCredentials: credentials
        );

        return new AuthResponseDto
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Email = usuario.Email,
            Nombre = usuario.Nombre,
            Rol = usuario.Rol.ToString()  
        };
    }
    
}