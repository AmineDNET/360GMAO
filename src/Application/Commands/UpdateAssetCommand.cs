using GMAO.Domain.Enums;
using MediatR;

namespace GMAO.Application.Commands;

public record UpdateAssetCommand(Guid Id, string Name, string Site, string Location, AssetStatus Status) : IRequest;
