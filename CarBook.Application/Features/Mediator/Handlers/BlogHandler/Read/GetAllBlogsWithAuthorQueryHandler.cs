using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResult;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandler.Read
{
    public class GetAllBlogsWithAuthorQueryHandler : IRequestHandler<GetAllBlogsWithAuthorQuery, List<GetAllBlogsWithAuthorQueryResult>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetAllBlogsWithAuthorQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }


        public async Task<List<GetAllBlogsWithAuthorQueryResult>> Handle(GetAllBlogsWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = _blogRepository.GetAllBlogsWithAuthors();
            return values.Select(x => new GetAllBlogsWithAuthorQueryResult
            {
                AuthorID = x.AuthorID,
                BlogID = x.BlogID,
                CategoryID = x.CategoryID,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                Title = x.Title,
                AuthorName = x.Author.Name,
                Description = x.Description,
                AuthorImageUrl=x.Author.ImageUrl,
                AuthorDescription = x.Author.Description,

            }).ToList();
        }
    }
}
