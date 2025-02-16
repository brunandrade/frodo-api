using Core.Messaging.Messaging;
using Core.Validations.Exceptions;
using Frodo.Pets.Domain.Entities;
using Frodo.Pets.Domain.Interfaces;
using MediatR;

namespace Frodo.Pets.Application.Commands;

public record RemovePetCommand(Guid Id) : ICommand;

public class RemovePetCommandHandler : ICommandHandler<RemovePetCommand>
{
    private readonly IPetRepository _petRepository;

    public RemovePetCommandHandler(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }

    public async Task<Unit> Handle(RemovePetCommand request, CancellationToken cancellationToken)
    {
        var pet = await _petRepository.GetByIdAsync<Pet>(request.Id, null, cancellationToken)
            ?? throw new BusinessException("RemovePetVaccine", "Pet não encontrado.");

        pet.Remove();
        _petRepository.Update(pet);
        await _petRepository.IUnitOfWork.Commit(cancellationToken);

        return Unit.Value;
    }
}