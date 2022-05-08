using DPNerd.Core.Communication;
using DPNerd.Notifications;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DPNerd.WebAPI.Core.Controllers;

[ApiController]
[Produces("application/json")]
public abstract class MainController : ControllerBase
{
    protected readonly INotificationHandler _notification;

    protected MainController(INotificationHandler notification)
    {
        _notification = notification;
    }
    protected ActionResult CustomResponse(object? result = null)
    {
        if (OperationIsValid())
        {
            return HttpContext.Request.Method switch
            {
                "PUT" or "DELETE" or "POST" => NoContent(),
                "GET" => result is null ? NotFound() : Ok(result),
                _ => Ok(result),
            };
        }
        return BadRequest(new ResponseValidation(_notification.GetNotifications()));
    }
    //protected ActionResult CustomResponse(string actionName, object? result = null, object? routeValues = null)
    //{
    //    if (OperationIsValid())
    //        if (actionName is not null)
    //            return CreatedAtAction(actionName, routeValues, result);
    //        else
    //            return Ok(result);

    //    return BadRequest(new ResponseValidation(_notification.GetNotifications()));
    //}
    protected ActionResult CustomResponse(ModelStateDictionary modelState)
    {
        foreach (var erro in modelState.Values.SelectMany(e => e.Errors))
        {
            AddErrorProcess(nameof(ModelStateDictionary), null, erro.ErrorMessage);
        }
        return CustomResponse();
    }
    protected ActionResult CustomResponse(ValidationResult validationResult)
    {
        foreach (var erro in validationResult.Errors)
        {
            AddErrorProcess(nameof(ValidationResult), erro.PropertyName, erro.ErrorMessage);
        }
        return CustomResponse();
    }
    protected ActionResult CustomResponse(ResponseResult response)
    {
        ResponseHasErrors(response);

        return CustomResponse();
    }
    protected ActionResult NotFound(string? detail = null)
        => NotFound(new ResponseNotFound(detail));
    protected bool ResponseHasErrors(ResponseResult response)
    {
        if (response == null) return false;

        if (response.Errors.Messages.Count == 0) return false;

        foreach (var mensagem in response.Errors.Messages)
        {
            AddErrorProcess(mensagem.Key, mensagem.Value);
        }
        return true;
    }
    protected bool OperationIsValid()
        => !_notification.HasNotifications();
    protected void AddErrorProcess(string type, string key, string message)
        => _notification.Notify(new Notification(type, key, message));
    protected void AddErrorProcess(string key, string message)
        => _notification.Notify(new Notification(key, message));
    protected void AddErrorProcess(string message)
        => _notification.Notify(new Notification(message));
    protected void ClearNotifications()
        => _notification.ClearNotifications();
}
