using MediatR;
using GMAO.Domain.Entities;
using GMAO.Domain.Enums;

namespace GMAO.Application.Commands;

public record CreateAssetCommand(string Name, string Site, string Location, AssetStatus Status) : IRequest<Guid>;
