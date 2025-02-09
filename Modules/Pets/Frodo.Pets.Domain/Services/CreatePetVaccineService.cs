using Core.Validations.Exceptions;
using Frodo.Pets.Domain.Dtos;
using Frodo.Pets.Domain.Entities;
using Frodo.Pets.Domain.Enums;
using Frodo.Pets.Domain.Interfaces;

namespace Frodo.Pets.Domain.Services;

public class CreatePetVaccineService : ICreatePetVaccineService
{
    private readonly int MonthlyIncrementDays = 30;
    private readonly int WeeklyIncrementDays = 7;

    public Pet Create(Pet pet, CreatePetVaccineDto createPetVaccineDto)
    {
        var petVaccine = pet.AddPetVaccine(createPetVaccineDto);
        SetRevaccinateDate(petVaccine, createPetVaccineDto);
        return pet;
    }

    private void SetRevaccinateDate(PetVaccine petVaccine, CreatePetVaccineDto createPetVaccineDto)
    {
        DateTime startDate = createPetVaccineDto.VaccinationIn;
        DateTime endDate = startDate.AddYears(1);

        switch (createPetVaccineDto.Frequency)
        {
            case VaccinationFrequencyEnum.Monthly:
                AddDates(petVaccine, startDate, endDate, MonthlyIncrementDays);
                break;
            case VaccinationFrequencyEnum.Weekly:
                AddDates(petVaccine, startDate, endDate, WeeklyIncrementDays);
                break;
            case VaccinationFrequencyEnum.Annual:
                petVaccine.AddPetVaccineDate(endDate);
                break;
            case VaccinationFrequencyEnum.Personalized:
                var numberOfDays = createPetVaccineDto.NumberOfDays
                    ?? throw new BusinessException("SetRevaccinateDate", "Número de dias obrigatório.");
                AddDates(petVaccine, startDate, endDate, numberOfDays);
                break;
        }
    }

    private static void AddDates(PetVaccine petVaccine, DateTime startDate, DateTime endDate, int incrementDays)
    {
        var dates = Enumerable
                .Range(1, (endDate - startDate).Days / incrementDays)
                .Select(i => startDate.AddDays(i * incrementDays))
                .Where(date => date <= endDate);

        foreach (var date in dates)
        {
            petVaccine.AddPetVaccineDate(date);
        }
    }
}