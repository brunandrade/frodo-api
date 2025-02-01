using Core.Messaging.Messaging;
using Core.Validations.Exceptions;
using Frodo.Pets.Application.Extensions;
using Frodo.Pets.Application.Models;
using Frodo.Pets.Domain.Entities;
using Frodo.Pets.Domain.Enums;
using Frodo.Pets.Domain.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Http;

namespace Frodo.Pets.Application.Commands;

public record UpdatePetCommand(
    Guid PetId,
    string? Name,
    int? Age,
    decimal? Weight,
    PetGenderEnum? Gender,
    IFormFile? Image) : ICommand<PetModel>;

public class UpdatePetCommandHandler : ICommandHandler<UpdatePetCommand, PetModel>
{
    private readonly IPetRepository _petRepository;

    public UpdatePetCommandHandler(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }

    public async Task<PetModel> Handle(UpdatePetCommand request, CancellationToken cancellationToken)
    {
        var pet = await _petRepository.GetByIdAsync<Pet>(request.PetId, null, cancellationToken)
            ?? throw new BusinessException("UpdatePet", "Pet não encontrado.");

        var updateDto = request.Map("url");
        pet.Update(updateDto);

        await _petRepository.AddAsync(pet, cancellationToken);
        await _petRepository.IUnitOfWork.Commit(cancellationToken);

        var data = pet.Adapt<PetModel>();
        return data;
    }
}