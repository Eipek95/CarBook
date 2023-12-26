using CarBook.Application.Features.CQRS.Queries.CarPricingQueries;
using CarBook.Application.Features.CQRS.Results.CarPricingResults;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.CarPricingHandlers.Read
{
    public class GetCarPricingQueryWithCarHandler : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
    {
        private readonly ICarPricingRepository _carPricingRepository;

        public GetCarPricingQueryWithCarHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }

        public async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
        {
            var values = _carPricingRepository.GetCarPricingWithCars();
            return values.Select(x => new GetCarPricingWithCarQueryResult
            {
                Amount = x.Amount,
                CarPricingID = x.CarPricingID,
                Brand = x.Car.Brand.Name,
                CoverImageUrl = x.Car.CoverImageUrl,
                Model = x.Car.Model
            }).ToList();
        }
    }
}
