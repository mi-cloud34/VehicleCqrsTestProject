
using Application.Features.Buses.Commands.CreateBus;
using Application.Features.Buses.Commands.DeleteBus;
using Application.Features.Buses.Commands.UpdateBus;
using Application.Features.Buses.Dtos;
using Application.Features.Buses.Models;
using Application.Features.Buses.Queries.GetByIdBus;
using Application.Features.Buses.Queries.GetListBus;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BusesController : BaseController
{
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdBusQuery getByIdBusQuery)
    {
        BusDto result = await Mediator.Send(getByIdBusQuery);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBusQuery getListBusQuery = new() { PageRequest = pageRequest };
        BusListModel result = await Mediator.Send(getListBusQuery);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBusCommand createBusCommand)
    {
        CreateBusDto result = await Mediator.Send(createBusCommand);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBusCommand updateBusCommand)
    {
        UpdateBusDto result = await Mediator.Send(updateBusCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteBusCommand deleteBusCommand)
    {
        DeleteBusDto result = await Mediator.Send(deleteBusCommand);
        return Ok(result);
    }
}