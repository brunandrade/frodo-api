﻿using Core.Messaging.Messaging;
using Core.Validations.Exceptions;
using Frodo.Pets.Domain.Entities;
using Frodo.Pets.Domain.Interfaces;
using MediatR;

namespace Frodo.Pets.Application.Commands;

public record RemovePetVaccineCommand(Guid Id, Guid PetVaccineId) : ICommand;

public class RemovePetVaccineCommandHandler : ICommandHandler<RemovePetVaccineCommand>
{
    private readonly IPetRepository _petRepository;

    public RemovePetVaccineCommandHandler(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }

    public async Task<Unit> Handle(RemovePetVaccineCommand request, CancellationToken cancellationToken)
    {
        var includes = new List<string> { "PetVaccines" };

        var pet = await _petRepository.GetByIdAsync<Pet>(request.Id, includes, cancellationToken)
            ?? throw new BusinessException("RemovePetVaccine", "Pet não encontrado.");

        var petVaccine = pet.Vaccines.FirstOrDefault(v => v.Id == request.PetVaccineId && !v.DeletedIn.HasValue)
            ?? throw new BusinessException("RemovePetVaccine", "Registro não encontrado.");

        petVaccine.Remove();

        _petRepository.Update(pet);
        await _petRepository.IUnitOfWork.Commit(cancellationToken);

        return Unit.Value;
    }
}