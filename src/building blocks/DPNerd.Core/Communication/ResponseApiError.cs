using System.Net;

namespace DPNerd.Core.Communication;

public class ResponseApiError
{
    public HttpStatusCode StatusCode { get; }
    public string Title { get; }
    public string Detail { get; }
}
