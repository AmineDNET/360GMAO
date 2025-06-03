using GMAO.Domain.Entities;
using GMAO.Domain.Enums;
using GMAO.Domain.Interfaces;
using MediatR;

namespace GMAO.Application.Commands;

public class CreateAssetCommandHandler : IRequestHandler<CreateAssetCommand, Guid>
{
    private readonly IRepository<Asset> _repository;

    public CreateAssetCommandHandler(IRepository<Asset> repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateAssetCommand request, CancellationToken cancellationToken)
    {
        var asset = Asset.Create(Guid.NewGuid(), request.Name, request.Site, request.Location, request.Status);
        await _repository.AddAsync(asset, cancellationToken);
        return asset.Id;
    }
}
