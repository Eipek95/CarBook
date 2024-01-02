using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.BlogInterfaces
{
    public interface IBlogRepository
    {
        public List<Blog> GetLast3BlogWithAuthors();
        public List<Blog> GetAllBlogsWithAuthors();
        public List<Blog> GetBlogByAuthorId(int id);
    }
}
