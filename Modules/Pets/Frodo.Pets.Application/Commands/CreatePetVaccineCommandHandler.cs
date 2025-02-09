using Core.Messaging.Messaging;
using Core.Validations.Exceptions;
using Frodo.Pets.Application.Extensions;
using Frodo.Pets.Application.Models;
using Frodo.Pets.Domain.Entities;
using Frodo.Pets.Domain.Enums;
using Frodo.Pets.Domain.Interfaces;
using Mapster;

namespace Frodo.Pets.Application.Commands;

public record CreatePetVaccineRequest(
    Guid MedicationId, 
    DateTime VaccinationIn, 
    VaccinationFrequencyEnum Frequency,
    int? NumberOfDays,
    string? DoctorName, 
    string? Laboratory);

public record CreatePetVaccineCommand(
    Guid PetId,
    Guid MedicationId,
    DateTime VaccinationIn,
    VaccinationFrequencyEnum Frequency,
    int? NumberOfDays,
    string? DoctorName,
    string? Laboratory) : ICommand<PetModel>;

public class CreatePetVaccineCommandHandler : ICommandHandler<CreatePetVaccineCommand, PetModel>
{
    private readonly IPetRepository _petRepository;
    private readonly ICreatePetVaccineService _createPetVaccineService;

    public CreatePetVaccineCommandHandler(
        IPetRepository petRepository, 
        ICreatePetVaccineService createPetVaccineService)
    {
        _petRepository = petRepository;
        _createPetVaccineService = createPetVaccineService;
    }

    public async Task<PetModel> Handle(CreatePetVaccineCommand request, CancellationToken cancellationToken)
    {
        var includes = new List<string>
        {
            "PetVaccines",
            "PetVaccines.Dates"
        };

        var pet = await _petRepository.GetByIdAsync<Pet>(request.PetId, includes, cancellationToken) 
            ?? throw new BusinessException("AddPetVaccine", "Pet não encontrado.");

        var createPetVaccineDto = request.MapToDto(); 
        _createPetVaccineService.Create(pet, createPetVaccineDto);

        await _petRepository.AddAsync(pet, cancellationToken);
        await _petRepository.IUnitOfWork.Commit(cancellationToken);

        var data = pet.Adapt<PetModel>();
        return data;
    }
}