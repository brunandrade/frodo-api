using Frodo.Pets.Application.Commands;
using Frodo.Pets.Domain.Dtos;

namespace Frodo.Pets.Application.Extensions;

public static class CreatePetVaccineDtoExtension
{
    public static CreatePetVaccineDto MapToDto(this CreatePetVaccineCommand command)
    {
        return new CreatePetVaccineDto
        {
            PetId = command.PetId,
            MedicationId = command.MedicationId,
            VaccinationIn = command.VaccinationIn,
            Frequency = command.Frequency,
            NumberOfDays = command.NumberOfDays,
            DoctorName = command.DoctorName,
            Laboratory = command.Laboratory,
        };
    }

    public static CreatePetVaccineCommand MapToCommand(this CreatePetVaccineRequest request, Guid petId)
    {
        return new CreatePetVaccineCommand(
            petId, 
            request.MedicationId, 
            request.VaccinationIn, 
            request.Frequency, 
            request.NumberOfDays, 
            request.DoctorName, 
            request.Laboratory);
    }
}