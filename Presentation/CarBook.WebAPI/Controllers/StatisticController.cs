using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private IMediator _mediator;

        public StatisticController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetCarCount")]
        public async Task<IActionResult> GetCarCountAsync()
        {
            var values = await _mediator.Send(new GetCarCountQuery());
            return Ok(values);
        }
    }
}
