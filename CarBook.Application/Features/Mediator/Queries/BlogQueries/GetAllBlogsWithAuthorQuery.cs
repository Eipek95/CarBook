using CarBook.Application.Features.Mediator.Results.BlogResult;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetAllBlogsWithAuthorQuery : IRequest<List<GetAllBlogsWithAuthorQueryResult>>
    {
    }
}
