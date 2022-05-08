using DPNerd.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace DPNerd.Core.Communication;

public class ResponseValidation : ProblemDetails
{
    public ICollection<Notification> Notifications { get; set; }

    public ResponseValidation(ICollection<Notification> notifications)
    {
        Notifications = notifications;
    }
}
