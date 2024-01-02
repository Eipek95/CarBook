using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResult;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandler.Read
{
    public class GetBlogByAuthorIdQueryHandler : IRequestHandler<GetBlogByAuthorIdQuery, List<GetBlogByAuthorIdQueryResult>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetBlogByAuthorIdQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<GetBlogByAuthorIdQueryResult>> Handle(GetBlogByAuthorIdQuery request, CancellationToken cancellationToken)
        {
            var values = _blogRepository.GetBlogByAuthorId(request.Id);
            return values.Select(x=>new GetBlogByAuthorIdQueryResult
            {
                AuthorID = x.AuthorID,
                BlogID = x.BlogID,
                AuthorName=x.Author.Name,
                AuthorDescription=x.Author.Description,
                AuthorImageUrl=x.Author.ImageUrl
            }).ToList();
        }
    }
}
