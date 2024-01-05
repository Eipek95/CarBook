using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _comments;

        public CommentsController(IGenericRepository<Comment> comments)
        {
            _comments = comments;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _comments.GetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        {
            _comments.Create(comment);
            return Ok("Yorum Başarıyla Eklendi");
        }
        [HttpDelete]
        public IActionResult RemoveComment(int id)
        {
            var comments = _comments.GetById(id);
            if (comments == null)
            {
                return NotFound();
            }
            _comments.Create(comments);
            return Ok("Yorum Başarıyla Silindi");
        }
        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
            var comments = _comments.GetById(comment.CommentID);
            if (comments == null)
            {
                return NotFound();
            }
            _comments.Update(comment);
            return Ok("Yorum Başarıyla Güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var comment = _comments.GetById(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }
    }
}
