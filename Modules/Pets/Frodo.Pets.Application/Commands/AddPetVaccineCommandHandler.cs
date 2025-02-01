using Core.Messaging.Messaging;
using Core.Validations.Exceptions;
using Frodo.Pets.Application.Models;
using Frodo.Pets.Domain.Entities;
using Frodo.Pets.Domain.Interfaces;
using Mapster;

namespace Frodo.Pets.Application.Commands;

public record AddPetVaccineCommand(
    Guid PetId,
    Guid MedicationId,
    DateTime VaccinationIn,
    DateTime RevaccinateIn,
    string? DoctorName,
    string? Laboratory) : ICommand<PetModel>;

public class AddPetVaccineCommandHandler : ICommandHandler<AddPetVaccineCommand, PetModel>
{
    private readonly IPetRepository _petRepository;

    public AddPetVaccineCommandHandler(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }

    public async Task<PetModel> Handle(AddPetVaccineCommand request, CancellationToken cancellationToken)
    {
        var pet = await _petRepository.GetByIdAsync<Pet>(request.PetId, cancellationToken) 
            ?? throw new BusinessException("AddPetVaccine", "Pet não encontrado.");

        await _petRepository.AddAsync(pet, cancellationToken);
        await _petRepository.IUnitOfWork.Commit(cancellationToken);

        var data = pet.Adapt<PetModel>();
        return data;
    }
}