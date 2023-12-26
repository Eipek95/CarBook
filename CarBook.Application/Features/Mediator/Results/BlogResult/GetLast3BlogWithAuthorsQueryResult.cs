﻿namespace CarBook.Application.Features.Mediator.Results.BlogResult
{
    public class GetLast3BlogWithAuthorsQueryResult
    {
        public int BlogID { get; set; }
        public string Title { get; set; }
        public int AuthorID { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryID { get; set; }

        public string AuthorName { get; set; }
    }
}
