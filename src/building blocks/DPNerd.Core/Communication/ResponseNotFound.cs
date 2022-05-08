using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DPNerd.Core.Communication;

public class ResponseNotFound : NotFoundResult
{
    public HttpStatusCode StatusCode { get; }
    public string Title { get; }
    public string Detail { get; }
    public ResponseNotFound(string detail = null)
    {
        StatusCode = HttpStatusCode.NotFound;
        Title = "Não encontrado";
        Detail = detail ?? "Consulta não retornou registros";
    }
}
