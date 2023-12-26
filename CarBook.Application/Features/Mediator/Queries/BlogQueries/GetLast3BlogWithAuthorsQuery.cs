using CarBook.Application.Features.Mediator.Results.BlogResult;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetLast3BlogWithAuthorsQuery : IRequest<List<GetLast3BlogWithAuthorsQueryResult>>
    {
    }
}
