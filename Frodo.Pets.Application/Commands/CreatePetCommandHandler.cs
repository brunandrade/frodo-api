using Core.Messaging.Messaging;
using Frodo.Pets.Application.Models;
using Frodo.Pets.Domain.Enums;
using Frodo.Pets.Domain.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Http;

namespace Frodo.Pets.Application.Commands;

public record CreatePetCommand(
    Guid UserId, 
    string Name, 
    int Age, 
    decimal Weight, 
    PetGenderEnum Gender,
    IFormFile Image) : ICommand<PetModel>;

public class CreatePetCommandHandler : ICommandHandler<CreatePetCommand, PetModel>
{
    private readonly IPetFactory _petFactory;
    private readonly IPetRepository _petRepository;

    public CreatePetCommandHandler(IPetFactory petFactory, IPetRepository petRepository)
    {
        _petFactory = petFactory;
        _petRepository = petRepository;
    }

    public async Task<PetModel> Handle(CreatePetCommand request, CancellationToken cancellationToken)
    {
        var pet = _petFactory.Create(request.Name, request.Age, request.Gender, request.Weight, "url");

        await _petRepository.AddAsync(pet, cancellationToken);
        await _petRepository.IUnitOfWork.Commit(cancellationToken);

        var data = pet.Adapt<PetModel>();
        return data;
    }
}