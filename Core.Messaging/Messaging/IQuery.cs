using MediatR;

namespace Core.Messaging.Messaging;

public interface IQuery<TResponse> : IRequest<TResponse>
{
}