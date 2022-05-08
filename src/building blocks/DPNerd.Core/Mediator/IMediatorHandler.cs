using DPNerd.Core.Messages;
using FluentValidation.Results;

namespace DPNerd.Core.Mediator;

public interface IMediatorHandler
{
    Task PublishEvent<TEvent>(TEvent @event) where TEvent : Event;
    Task<ValidationResult> SendCommand<TCommand>(TCommand comando) where TCommand : Command;
}