using Core.Messaging.Messaging;
using Frodo.Pets.Application.Specifications;
using Frodo.Pets.Domain.Entities;
using Frodo.Pets.Domain.Interfaces;
using Mapster;
using MediatR;

namespace Frodo.Pets.Application.Queries;

public record GetPetByOwnerIdQuery(Guid UserId) : IQuery<IEnumerable<GetPetByOwnerIdResponse>>;

public record GetPetByOwnerIdResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Race { get; set; }
    public int Age { get; set; }
    public string UserName { get; set; }
}

public class GetPetByOwnerIdQueryHandler : IRequestHandler<GetPetByOwnerIdQuery, IEnumerable<GetPetByOwnerIdResponse>>
{
    private readonly IPetRepository _petRepository;

    public GetPetByOwnerIdQueryHandler(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }

    public async Task<IEnumerable<GetPetByOwnerIdResponse>> Handle(GetPetByOwnerIdQuery request, CancellationToken cancellationToken)
    {
        var spec = new PetSpecification(request.UserId);
        var pets = await _petRepository.FindAsync<Pet>(spec, cancellationToken);

        var data = pets.Adapt<IEnumerable<GetPetByOwnerIdResponse>>();
        return data;
    }
}