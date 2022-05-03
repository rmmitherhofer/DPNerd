using DPNerd.Core.Communication;
using DPNerd.WebAPI.Core.Identity;
using DPNerd.WebApp.MVC.Models;
using Microsoft.Extensions.Options;

namespace DPNerd.WebApp.MVC.Services;

public interface IAuthService
{
    Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin);
    Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro);
    Task<UsuarioRespostaLogin> Logout(UsuarioLogin usuarioLogin);
}
public class AuthService : Service, IAuthService
{
    private readonly HttpClient _httpClient;
    public AuthService(HttpClient httpClient, IOptions<AppSettings> settings)
    {
        _httpClient = httpClient;
    }

    public async Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin)
    {
        var content = SerializarConteudo(usuarioLogin);

        var response = await _httpClient.PostAsync("/api/identity/autenticar", content);

        if (!ResponseEhValido(response))
        {
            return new UsuarioRespostaLogin
            {
                ResponseResult = await DeserializarResponse<ResponseResult>(response)
            };
        }
        return await DeserializarResponse<UsuarioRespostaLogin>(response);
    }

    public Task<UsuarioRespostaLogin> Logout(UsuarioLogin usuarioLogin)
    {
        throw new NotImplementedException();
    }

    public async Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro)
    {
        var content = SerializarConteudo(usuarioRegistro);

        var response = await _httpClient.PostAsync("/api/identity/nova-conta", content);

        if (!ResponseEhValido(response))
        {
            return new UsuarioRespostaLogin
            {
                ResponseResult = await DeserializarResponse<ResponseResult>(response)
            };
        }
        return await DeserializarResponse<UsuarioRespostaLogin>(response);
    }
}
