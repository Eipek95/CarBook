using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistance.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _carBookContext;

        public BlogRepository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

        public List<Blog> GetLast3BlogWithAuthors()
        {
            var values = _carBookContext.Blogs.Include(x => x.Author).OrderByDescending(x => x.BlogID).Take(3).ToList();
            return values;
        }
    }
}
