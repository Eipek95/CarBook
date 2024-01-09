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

        [HttpGet("GetLocationCount")]
        public async Task<IActionResult> GetLocationCountAsync()
        {
            var values = await _mediator.Send(new GetLocationCountQuery());
            return Ok(values);
        }

        [HttpGet("GetAuthorCount")]
        public async Task<IActionResult> GetAuthorCountAsync()
        {
            var values = await _mediator.Send(new GetAuthorCountQuery());
            return Ok(values);
        }

        [HttpGet("GetBlogCount")]
        public async Task<IActionResult> GetBlogCountAsync()
        {
            var values = await _mediator.Send(new GetBlogCountQuery());
            return Ok(values);
        }
        [HttpGet("GetBrandCount")]
        public async Task<IActionResult> GetBrandCountAsync()
        {
            var values = await _mediator.Send(new GetBrandCountQuery());
            return Ok(values);
        }
        [HttpGet("GetAvgRentPriceForDaily")]
        public async Task<IActionResult> GetAvgRentPriceForDailyAsync()
        {
            var values = await _mediator.Send(new GetAvgRentPriceForDailyQuery());
            return Ok(values);
        }

        [HttpGet("GetAvgRentPriceForWeekly")]
        public async Task<IActionResult> GetAvgRentPriceForWeeklyAsync()
        {
            var values = await _mediator.Send(new GetAvgRentPriceForWeeklyQuery());
            return Ok(values);
        }

        [HttpGet("GetAvgRentPriceForMonthly")]
        public async Task<IActionResult> GetAvgRentPriceForMonthlyAsync()
        {
            var values = await _mediator.Send(new GetAvgRentPriceForMonthlyQuery());
            return Ok(values);
        }

        [HttpGet("GetCarCountByTranmissionIsAuto")]
        public async Task<IActionResult> GetCarCountByTranmissionIsAutoAsync()
        {
            var values = await _mediator.Send(new GetCarCountByTranmissionIsAutoQuery());
            return Ok(values);
        }

        [HttpGet("GetBrandNameByMaxCar")]
        public async Task<IActionResult> GetBrandNameByMaxCarAsync()
        {
            var values = await _mediator.Send(new GetBrandNameByMaxCarQuery());
            return Ok(values);
        }

        [HttpGet("GetBlogTitleByMaxBlogComment")]
        public async Task<IActionResult> GetBlogTitleByMaxBlogCommentAsync()
        {
            var values = await _mediator.Send(new GetBlogTitleByMaxBlogCommentQuery());
            return Ok(values);
        }

        [HttpGet("GetCarCountByKmSmallerThen1000")]
        public async Task<IActionResult> GetCarCountByKmSmallerThen1000Async()
        {
            var values = await _mediator.Send(new GetCarCountByKmSmallerThen1000Query());
            return Ok(values);
        }

        [HttpGet("GetCarCountByFuelGasolineOrDiesel")]
        public async Task<IActionResult> GetCarCountByFuelGasolineOrDieselAsync()
        {
            var result = await _mediator.Send(new GetCarCountByFuelGasolineOrDieselQuery());

            var carCountByFuelGasolineOrDiesel = result.CarCountByFuelGasolineOrDiesel;

            var gasolineCount = carCountByFuelGasolineOrDiesel.Item1;
            var dieselCount = carCountByFuelGasolineOrDiesel.Item2;

            var value = new
            {
                DieselCount = dieselCount,
                GasolineCount = gasolineCount,
            };

            return Ok(value);
        }

        [HttpGet("GetCarCountByFuelElectric")]
        public async Task<IActionResult> GetCarCountByFuelElectricAsync()
        {
            var values = await _mediator.Send(new GetCarCountByFuelElectricQuery());
            return Ok(values);
        }

        [HttpGet("GetCarBrandAndModelByRentPriceDailyMax")]
        public async Task<IActionResult> GetCarBrandAndModelByRentPriceDailyMaxAsync()
        {
            var values = await _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMaxQuery());
            return Ok(values);
        }

        [HttpGet("GetCarBrandAndModelByRentPriceDailyMin")]
        public async Task<IActionResult> GetCarBrandAndModelByRentPriceDailyMinAsync()
        {
            var values = await _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMinQuery());
            return Ok(values);
        }
    }
}
