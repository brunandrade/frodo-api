using Core.Messaging.Messaging;
using Core.Validations.Exceptions;
using Frodo.Pets.Application.Extensions;
using Frodo.Pets.Application.Models;
using Frodo.Pets.Domain;
using Frodo.Pets.Domain.Enums;
using Frodo.Pets.Domain.Interfaces;
using Mapster;

namespace Frodo.Pets.Application.Commands;

public record CreatePetVaccineRequest(
    Guid MedicationId, 
    DateTime VaccinationIn, 
    FrequencyEnum Frequency,
    int? NumberOfDays,
    string? DoctorName, 
    string? Laboratory);

public record CreatePetVaccineCommand(
    Guid PetId,
    Guid MedicationId,
    DateTime VaccinationIn,
    FrequencyEnum Frequency,
    int? NumberOfDays,
    string? DoctorName,
    string? Laboratory) : ICommand<PetModel>;

public class CreatePetVaccineCommandHandler : ICommandHandler<CreatePetVaccineCommand, PetModel>
{
    private readonly IPetRepository _petRepository;
    public CreatePetVaccineCommandHandler(
        IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }

    public async Task<PetModel> Handle(CreatePetVaccineCommand request, CancellationToken cancellationToken)
    {
        var includes = new List<string>
        {
            "Vaccines",
            "Vaccines.Dates"
        };

        var pet = await _petRepository.GetByIdAsync<Pet>(request.PetId, includes, cancellationToken) 
            ?? throw new BusinessException("AddPetVaccine", "Pet não encontrado.");

        var createPetVaccineDto = request.MapToDto(); 

        _petRepository.Update(pet);
        await _petRepository.IUnitOfWork.Commit(cancellationToken);

        var data = pet.Adapt<PetModel>();
        return data;
    }
}