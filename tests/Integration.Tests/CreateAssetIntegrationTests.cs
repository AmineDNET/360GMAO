using GMAO.Application.Commands;
using GMAO.Domain.Entities;
using GMAO.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using GMAO.Infrastructure.Data;
using Xunit;

namespace GMAO.IntegrationTests;

public class CreateAssetIntegrationTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _factory;

    public CreateAssetIntegrationTests(CustomWebApplicationFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task CreateAssetCommand_Persists_To_Database()
    {
        using var scope = _factory.Services.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        var context = scope.ServiceProvider.GetRequiredService<GMAODbContext>();

        var command = new CreateAssetCommand("Pump", "SiteA", "Loc1", AssetStatus.Active);
        var id = await mediator.Send(command);

        var asset = await context.Assets.FindAsync(id);
        Assert.NotNull(asset);
        Assert.Equal("Pump", asset!.Name);
    }
}
