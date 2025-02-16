using Core.Messaging.Messaging;
using Core.Validations.Exceptions;
using Frodo.Pets.Application.Models;
using Frodo.Pets.Domain.Entities;
using Frodo.Pets.Domain.Interfaces;
using Mapster;

namespace Frodo.Pets.Application.Queries;

public record GetPetByIdQuery(Guid Id) : IQuery<PetModel>;

public class GetPetByIdQueryHandler : IQueryHandler<GetPetByIdQuery, PetModel>
{
    private readonly IPetRepository _petRepository;

    public GetPetByIdQueryHandler(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }

    public async Task<PetModel> Handle(GetPetByIdQuery request, CancellationToken cancellationToken)
    {
        var includes = new List<string>
        {
            "Owners",
            "Vaccines",
            "Vaccines.Dates"
        };

        var pet = await _petRepository.GetByIdAsync<Pet>(request.Id, includes, cancellationToken)
            ?? throw new BusinessException("GetPetById", "Pet não encontrado.");

        var data = pet.Adapt<PetModel>();
        return data;
    }
}