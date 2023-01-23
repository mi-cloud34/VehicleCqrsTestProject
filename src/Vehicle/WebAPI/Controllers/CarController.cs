
using Application.Features.Cars.Commands.CreateCar;
using Application.Features.Cars.Commands.DeleteCar;
using Application.Features.Cars.Commands.UpdateCar;
using Application.Features.Cars.Dtos;
using Application.Features.Cars.Models;
using Application.Features.Cars.Queries.GetByIdCar;
using Application.Features.Cars.Queries.GetListCar;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : BaseController
{
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdCarQuery getByIdCarQuery)
    {
        CarDto result = await Mediator.Send(getByIdCarQuery);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCarQuery getListCarQuery = new() { PageRequest = pageRequest };
        CarListModel result = await Mediator.Send(getListCarQuery);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCarCommand createCarCommand)
    {
        CreateCarDto result = await Mediator.Send(createCarCommand);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCarCommand updateCarCommand)
    {
        UpdateCarDto result = await Mediator.Send(updateCarCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteCarCommand deleteCarCommand)
    {
        DeleteCarDto result = await Mediator.Send(deleteCarCommand);
        return Ok(result);
    }
}