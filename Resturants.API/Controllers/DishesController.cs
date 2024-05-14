using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes.Commands.CreateDish;
using Restaurants.Application.Dishes.Commands.DeleteAllDishes;
using Restaurants.Application.Dishes.Commands.DeleteDish;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Application.Dishes.Queries.GetDish;
using Restaurants.Application.Restaurants.Queries.GetAllDishesQuery;
using Restaurants.Domain.Entites;

namespace Resturants.API.Controllers;

[ApiController]
[Route("api/restaurant/{restaurantId}/dishes")]
public class DishesController(IMediator mediator): ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateDish([FromRoute] int restaurantId, [FromBody] CreateDishCommand command)
    {
        command.RestaurantId = restaurantId;
        var dishId = await mediator.Send(command);
        return CreatedAtAction(nameof(CreateDish), new {restaurantId, dishId}, null);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DishDto>>> GetAllDishes([FromRoute] int restaurantId)
    {
        var dishes = await mediator.Send(new GetAllDishesQuery(restaurantId));
        return Ok(dishes);
    }

    [HttpGet("{dishId}")]
    public async Task<ActionResult> GetDish([FromRoute] int restaurantId, [FromRoute] int dishId)
    {
        var dish = await mediator.Send(new GetDishQuery(restaurantId, dishId));
        return Ok(dish);
    }

    [HttpDelete("{dishId}")]
    public async Task<ActionResult> DeleteDish([FromRoute] int restaurantId, [FromRoute] int dishId)
    {
        await mediator.Send(new DeleteDishCommand(restaurantId, dishId));
        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteAllDishes([FromRoute] int restaurantId)
    {
        await mediator.Send(new DeleteAllDishesCommand(restaurantId));
        return NoContent();
    }
}
