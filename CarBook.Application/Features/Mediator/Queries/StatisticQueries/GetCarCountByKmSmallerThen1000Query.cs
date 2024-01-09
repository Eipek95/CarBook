using CarBook.Application.Features.Mediator.Results.StatisticResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.StatisticQueries
{
    public class GetCarCountByKmSmallerThen1000Query : IRequest<GetCarCountByKmSmallerThen1000QueryResult>
    {
    }
}
