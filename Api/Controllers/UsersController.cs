using Api.Contracts.Dtos;
using Domain.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateUserDto createUserDto, 
        [FromServices] ICreateUserUseCase useCase)
    {
        var useCaseResult = await useCase.CreateUser(createUserDto);

        return useCaseResult.Match<IActionResult>(
            id => Ok(id),
            badRequest => BadRequest(badRequest.Message));
    }
    
    [HttpGet]
    [Route("{id:long}")]
    public async Task<IActionResult> Get(long id, 
        [FromServices] IGetUserUseCase useCase)
    {
        var useCaseResult = await useCase.GetUser(id);

        return useCaseResult.Match<IActionResult>(
            Ok,
            _ => NotFound());
    }
    
    [HttpGet]
    public async Task<IActionResult> List([FromQuery] PaginationDto paginationDto, 
        [FromServices] IGetUsersListUseCase useCase)
    {
        var useCaseResult = await useCase.GetUsers(paginationDto);
        
        return useCaseResult.Match<IActionResult>(
            Ok,
            badRequest => BadRequest(badRequest.Message));
    }
    
    [HttpDelete]
    [Route("{id:long}")]
    public async Task<IActionResult> Delete(long id, 
        [FromServices] IDeleteUserUseCase useCase)
    {
        var useCaseResult = await useCase.DeleteUser(id);
        
        return useCaseResult.Match<IActionResult>(
            Ok,
            _ => NotFound());
    }
}