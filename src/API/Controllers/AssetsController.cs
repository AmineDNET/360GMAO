using MediatR;
using Microsoft.AspNetCore.Mvc;
using GMAO.Application.Commands;
using GMAO.Domain.Enums;

namespace GMAO.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssetsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AssetsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsset([FromBody] CreateAssetRequest request)
    {
        var id = await _mediator.Send(new CreateAssetCommand(request.Name, request.Site, request.Location, request.Status));
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id) => Ok();
}

public record CreateAssetRequest(string Name, string Site, string Location, AssetStatus Status);
