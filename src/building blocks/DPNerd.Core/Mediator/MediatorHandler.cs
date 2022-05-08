using DPNerd.Core.Messages;
using FluentValidation.Results;
using MediatR;
using System.Diagnostics;

namespace DPNerd.Core.Mediator;

public class MediatorHandler : IMediatorHandler
{
    private readonly IMediator _mediator;

    public MediatorHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<ValidationResult> SendCommand<TCommand>(TCommand command) where TCommand : Command
        => await _mediator.Send(command);


    public async Task PublishEvent<TEvent>(TEvent @event) where TEvent : Event
    {
        Debug.WriteLine($"publicando mensagem Mediador {@event}");

        await _mediator.Publish(@event);
    }
}
