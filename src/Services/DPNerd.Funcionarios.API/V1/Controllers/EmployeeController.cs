using DPNerd.Core.Communication;
using DPNerd.Core.Mediator;
using DPNerd.Employees.Application.Commands;
using DPNerd.Notifications;
using DPNerd.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DPNerd.Employees.API.V1.Controllers;
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/employee")]
public class EmployeeController : MainController
{
    private readonly IMediatorHandler _mediatorHandler;
    public EmployeeController(INotificationHandler notification, IMediatorHandler mediatorHandler) : base(notification)
    {
        _mediatorHandler = mediatorHandler;
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ResponseNotFound))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ResponseValidation))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ResponseApiError))]
    public async Task<IActionResult> GetAll()
    {
        return CustomResponse();
    }
    [HttpGet("{id:guid}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ResponseNotFound))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ResponseValidation))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ResponseApiError))]
    public async Task<IActionResult> GetById(Guid id)
    {
        var employee = id;

        return CustomResponse();
    }
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ResponseValidation))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ResponseApiError))]
    public async Task<IActionResult> Post(InsertEmployeeCommand employee) 
        => CustomResponse(await _mediatorHandler.SendCommand(employee));

    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ResponseValidation))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ResponseApiError))]
    public async Task<IActionResult> Put()
    {
        return CustomResponse();
    }
    [HttpDelete]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ResponseValidation))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ResponseApiError))]
    public async Task<IActionResult> Delete()
    {
        return CustomResponse();
    }
}
