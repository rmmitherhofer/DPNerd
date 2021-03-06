using DPNerd.Core.Communication;
using DPNerd.WebApp.MVC.Exceptions;
using System.Net;
using System.Text;
using System.Text.Json;

namespace DPNerd.WebApp.MVC.Services;

public abstract class Service
{
    protected StringContent SerializarConteudo(object dado)
    {
        return new StringContent(JsonSerializer.Serialize(dado), Encoding.UTF8, "application/json");
    }

    protected async Task<T> DeserializarResponse<T>(HttpResponseMessage response)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync(), options);
    }

    protected bool ResponseEhValido(HttpResponseMessage response)
    {
        switch (response.StatusCode)
        {
            case HttpStatusCode.Unauthorized:
            case HttpStatusCode.Forbidden:
            case HttpStatusCode.NotFound:
            case HttpStatusCode.InternalServerError:
                throw new CustomHttpRequestException(response.StatusCode);
            case HttpStatusCode.BadRequest:
                return false;
        }

        response.EnsureSuccessStatusCode();
        return true;
    }

    protected ResponseResult RetornoOk()
    {
        return new ResponseResult();
    }
}
