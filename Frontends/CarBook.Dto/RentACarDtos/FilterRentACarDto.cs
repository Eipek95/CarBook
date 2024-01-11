namespace CarBook.Dto.RentACarDtos
{
    public class FilterRentACarDto
    {
        public int CarID { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public decimal Amount { get; set; }
    }
}
