using Frodo.Pets.Application.Commands;
using Frodo.Pets.Domain.Dtos;

namespace Frodo.Pets.Application.Extensions;

public static class CreatePetVaccineDtoExtension
{
    public static CreatePetVaccineDto Map(this CreatePetVaccineCommand command)
    {
        return new CreatePetVaccineDto
        {
            PetId = command.PetId,
            MedicationId = command.MedicationId,
            VaccinationIn = command.VaccinationIn,
            RevaccinateIn = command.RevaccinateIn,
            DoctorName = command.DoctorName,
            Laboratory = command.Laboratory,
        };
    }
}