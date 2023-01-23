
using Application.Features.Boats.Commands.CreateBoat;
using Application.Features.Boats.Commands.DeleteBoat;
using Application.Features.Boats.Commands.UpdateBoat;
using Application.Features.Boats.Dtos;
using Application.Features.Boats.Models;
using Application.Features.Boats.Queries.GetByIdBoat;
using Application.Features.Boats.Queries.GetListBoat;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BoatsController : BaseController
{
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdBoatQuery getByIdBoatQuery)
    {
        BoatDto result = await Mediator.Send(getByIdBoatQuery);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBoatQuery getListBoatQuery = new() { PageRequest = pageRequest };
        BoatListModel result = await Mediator.Send(getListBoatQuery);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBoatCommand createBoatCommand)
    {
        CreateBoatDto result = await Mediator.Send(createBoatCommand);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBoatCommand updateBoatCommand)
    {
        UpdateBoatDto result = await Mediator.Send(updateBoatCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteBoatCommand deleteBoatCommand)
    {
        DeleteBoatDto result = await Mediator.Send(deleteBoatCommand);
        return Ok(result);
    }
}