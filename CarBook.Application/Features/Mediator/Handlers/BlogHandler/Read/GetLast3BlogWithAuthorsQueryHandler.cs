using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResult;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandler.Read
{
    public class GetLast3BlogWithAuthorsQueryHandler : IRequestHandler<GetLast3BlogWithAuthorsQuery, List<GetLast3BlogWithAuthorsQueryResult>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetLast3BlogWithAuthorsQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<GetLast3BlogWithAuthorsQueryResult>> Handle(GetLast3BlogWithAuthorsQuery request, CancellationToken cancellationToken)
        {
            var values = _blogRepository.GetLast3BlogWithAuthors();
            return values.Select(x => new GetLast3BlogWithAuthorsQueryResult
            {
                AuthorID = x.AuthorID,
                BlogID = x.BlogID,
                CategoryID = x.CategoryID,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                Title = x.Title,
                AuthorName = x.Author.Name
            }).ToList();
        }
    }
}
