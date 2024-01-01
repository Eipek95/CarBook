namespace CarBook.Dto.BlogDtos
{
    public class GetBlogById
    {
        public int blogID { get; set; }
        public string title { get; set; }
        public int authorID { get; set; }
        public string coverImageUrl { get; set; }
        public DateTime createdDate { get; set; }
        public int categoryID { get; set; }
        public string description { get; set; }
    }

}
