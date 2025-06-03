using System.Threading;
using System.Threading.Tasks;
using GMAO.Application.Commands;
using GMAO.Domain.Entities;
using GMAO.Domain.Enums;
using GMAO.Domain.Interfaces;
using Moq;
using Xunit;

namespace GMAO.Application.Tests;

public class CreateAssetCommandHandlerTests
{
    [Fact]
    public async Task Handle_Should_Add_Asset_And_Return_Id()
    {
        // Arrange
        var repoMock = new Mock<IRepository<Asset>>();
        var handler = new CreateAssetCommandHandler(repoMock.Object);
        var command = new CreateAssetCommand("Pump", "SiteA", "Loc1", AssetStatus.Active);

        // Act
        var id = await handler.Handle(command, CancellationToken.None);

        // Assert
        repoMock.Verify(r => r.AddAsync(It.Is<Asset>(a => a.Name == "Pump"), It.IsAny<CancellationToken>()), Times.Once);
        Assert.NotEqual(Guid.Empty, id);
    }
}
