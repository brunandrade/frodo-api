using MediatR;

namespace Core.Messaging.Messaging;

public interface ICommand : IRequest
{
}

public interface ICommand<TResponse> : IRequest<TResponse>
{
}
