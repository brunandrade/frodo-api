using Frodo.Pets.Domain.Dtos;
using Frodo.Pets.Domain.Entities;
using Frodo.Pets.Domain.Enums;
using Frodo.Pets.Domain.Interfaces;

namespace Frodo.Pets.Domain.Services;

public class CreatePetVaccineService : ICreatePetVaccineService
{
    public Pet Create(Pet pet, CreatePetVaccineDto createPetVaccineDto)
    {
        var petVaccine = pet.AddPetVaccine(createPetVaccineDto);
        SetRevaccinateDate(petVaccine, createPetVaccineDto);
        return pet;
    }

    private static void SetRevaccinateDate(PetVaccine petVaccine, CreatePetVaccineDto createPetVaccineDto)
    {
        DateTime nextDate = createPetVaccineDto.VaccinationIn;

        switch (createPetVaccineDto.Frequency)
        {
            case VaccinationFrequencyEnum.Monthly:
                while ((nextDate = nextDate.AddMonths(1)) <= createPetVaccineDto.VaccinationIn.AddYears(1))
                {
                    petVaccine.AddPetVaccineDate(nextDate);
                }
                break;

            case VaccinationFrequencyEnum.Weekly:
                while ((nextDate = nextDate.AddDays(7)) <= createPetVaccineDto.VaccinationIn.AddYears(1))
                {
                    petVaccine.AddPetVaccineDate(nextDate);
                }
                break;

            case VaccinationFrequencyEnum.Annual:
                petVaccine.AddPetVaccineDate(createPetVaccineDto.VaccinationIn.AddYears(1));
                break;

            case VaccinationFrequencyEnum.Personalized:
                if (createPetVaccineDto.NumberOfDays.HasValue && createPetVaccineDto.NumberOfDays.Value > 0)
                {
                    while ((nextDate = nextDate.AddDays(createPetVaccineDto.NumberOfDays.Value)) <= createPetVaccineDto.VaccinationIn.AddYears(1))
                    {
                        petVaccine.AddPetVaccineDate(nextDate);
                    }
                }
                break;
        }
    }
}