using GMAO.Domain.Entities;
using GMAO.Domain.Enums;
using GMAO.Domain.Interfaces;
using MediatR;

namespace GMAO.Application.Commands;

public class UpdateAssetCommandHandler : IRequestHandler<UpdateAssetCommand>
{
    private readonly IAssetRepository _repository;

    public UpdateAssetCommandHandler(IAssetRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateAssetCommand request, CancellationToken cancellationToken)
    {
        var asset = await _repository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new InvalidOperationException($"Asset {request.Id} not found");

        asset.Update(request.Name, request.Site, request.Location, request.Status);
        await _repository.UpdateAsync(asset, cancellationToken);
        return Unit.Value;
    }
}
