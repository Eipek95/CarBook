using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;

namespace CarBook.Persistance.Repositories.CommentRepositories
{
    public class CommentRepository<T> : IGenericRepository<Comment>
    {
        private readonly CarBookContext _carBookContext;

        public CommentRepository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

        public void Create(Comment entity)
        {
            _carBookContext.Comments.Add(entity);
            _carBookContext.SaveChanges();
        }

        public List<Comment> GetAll()
        {
            return _carBookContext.Comments.Select(x => new Comment
            {
                BlogId = x.BlogId,
                CommentID = x.CommentID,
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                Name = x.Name,
            }).ToList();
        }

        public Comment GetById(int id)
        {
            return _carBookContext.Comments.Find(id);
        }

        public void Remote(Comment entity)
        {
            _carBookContext.Comments.Remove(entity);
            _carBookContext.SaveChanges();
        }

        public void Update(Comment entity)
        {
            _carBookContext.Comments.Update(entity);
            _carBookContext.SaveChanges();
        }
    }
}
