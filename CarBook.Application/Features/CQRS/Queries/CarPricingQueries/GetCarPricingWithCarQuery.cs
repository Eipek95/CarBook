﻿using CarBook.Application.Features.CQRS.Results.CarPricingResults;
using MediatR;

namespace CarBook.Application.Features.CQRS.Queries.CarPricingQueries
{
    public class GetCarPricingWithCarQuery : IRequest<List<GetCarPricingWithCarQueryResult>>
    {
    }
}
