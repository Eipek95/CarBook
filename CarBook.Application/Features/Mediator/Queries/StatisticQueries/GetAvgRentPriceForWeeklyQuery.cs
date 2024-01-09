﻿using CarBook.Application.Features.Mediator.Results.StatisticResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.StatisticQueries
{
    public class GetAvgRentPriceForWeeklyQuery : IRequest<GetAvgRentPriceForWeeklyQueryResult>
    {
    }
}
