using FluentValidation.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace DPNerd.Core.Messages;

public abstract class Command : Message, IRequest<ValidationResult>
{
    public DateTime Timestamp { get; private set; }
    [JsonIgnore]
    public ValidationResult ValidationResult { get; set; }

    protected Command()
        => Timestamp = DateTime.Now;
    public virtual bool IsValid()
        => throw new NotImplementedException();
}
