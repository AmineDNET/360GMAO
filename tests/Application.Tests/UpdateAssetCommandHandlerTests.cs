using System.Threading;
using System.Threading.Tasks;
using GMAO.Application.Commands;
using GMAO.Domain.Entities;
using GMAO.Domain.Enums;
using GMAO.Domain.Interfaces;
using Moq;
using Xunit;

namespace GMAO.Application.Tests;

public class UpdateAssetCommandHandlerTests
{
    [Fact]
    public async Task Handle_Should_Update_Asset()
    {
        // Arrange
        var id = Guid.NewGuid();
        var asset = Asset.Create(id, "Pump", "SiteA", "Loc1", AssetStatus.Active);
        var repoMock = new Mock<IRepository<Asset>>();
        repoMock.Setup(r => r.GetByIdAsync(id, It.IsAny<CancellationToken>())).ReturnsAsync(asset);
        var handler = new UpdateAssetCommandHandler(repoMock.Object);
        var command = new UpdateAssetCommand(id, "Pump2", "SiteB", "Loc2", AssetStatus.OutOfService);

        // Act
        await handler.Handle(command, CancellationToken.None);

        // Assert
        repoMock.Verify(r => r.UpdateAsync(asset, It.IsAny<CancellationToken>()), Times.Once);
        Assert.Equal("Pump2", asset.Name);
        Assert.Equal(AssetStatus.OutOfService, asset.Status);
    }

    [Fact]
    public async Task Handle_Should_Throw_When_Name_Is_Empty()
    {
        var id = Guid.NewGuid();
        var asset = Asset.Create(id, "Pump", "SiteA", "Loc1", AssetStatus.Active);
        var repoMock = new Mock<IRepository<Asset>>();
        repoMock.Setup(r => r.GetByIdAsync(id, It.IsAny<CancellationToken>())).ReturnsAsync(asset);
        var handler = new UpdateAssetCommandHandler(repoMock.Object);
        var command = new UpdateAssetCommand(id, "", "SiteB", "Loc2", AssetStatus.Active);

        await Assert.ThrowsAsync<ArgumentException>(() => handler.Handle(command, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_Should_Throw_When_Status_Is_Invalid()
    {
        var id = Guid.NewGuid();
        var asset = Asset.Create(id, "Pump", "SiteA", "Loc1", AssetStatus.Active);
        var repoMock = new Mock<IRepository<Asset>>();
        repoMock.Setup(r => r.GetByIdAsync(id, It.IsAny<CancellationToken>())).ReturnsAsync(asset);
        var handler = new UpdateAssetCommandHandler(repoMock.Object);
        var invalidStatus = (AssetStatus)99;
        var command = new UpdateAssetCommand(id, "Pump2", "SiteB", "Loc2", invalidStatus);

        await Assert.ThrowsAsync<ArgumentException>(() => handler.Handle(command, CancellationToken.None));
    }
}
