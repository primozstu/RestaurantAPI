using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Application.Restaurants.Commands.EditRestaurant;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;

namespace Resturants.API.Controllers;

[ApiController]
[Route("api/resturants")]
public class ResturantsController(/*IRestaurantsService restaurantService*/IMediator mediator) : ControllerBase
{
    [HttpGet]
    //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<RestaurantDto>))]
    public async Task<ActionResult<IEnumerable<RestaurantDto>>> GetAll()
    {
        var resturants = await mediator.Send(new GetAllRestaurantsQuery());
        //var resturants = await restaurantService.GetAllRestaurants();
        return Ok(resturants);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RestaurantDto>> GetById([FromRoute]int id)
    {
        var resturant = await mediator.Send(new GetRestaurantByIdQuery(id));
        //var resturant = await restaurantService.GetRestaurantById(id);
        return Ok(resturant);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] /* ApiControllert attribute automaticaly assumes that this argument came from body*//*CreaetRestaurantDto*/CreateRestaurantCommand command)
    {
        // ModelState manually validation if ApiController attribute is not used
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        int id = await mediator.Send(command);
        //int id = await restaurantService.createRestaurant(createRestaurantDto);
        return CreatedAtAction(nameof(GetById), new {id}, null);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteById([FromRoute]int id)
    {
        await mediator.Send(new DeleteRestaurantCommand(id));
        return NoContent();
    }

    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Edit([FromRoute]int id, [FromBody] EditRestaurantCommand command)
    {
        command.Id = id;
        await mediator.Send(command);
        return NoContent();
    }
}
