namespace CarBook.Application.Features.CQRS.Queries.AboutQueries
{
    public class GetAboutByIdQuery
    {

        public GetAboutByIdQuery(int ıd)
        {
            Id = ıd;
        }
        public int Id { get; set; }
    }
}
