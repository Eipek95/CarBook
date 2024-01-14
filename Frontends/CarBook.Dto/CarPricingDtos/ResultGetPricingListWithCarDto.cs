namespace CarBook.Dto.CarPricingDtos
{
    public class ResultGetPricingListWithCarDto
    {
        public string model { get; set; }
        public decimal dailyAmount { get; set; }
        public decimal weeklyAmount { get; set; }
        public decimal monthlyAmount { get; set; }
        public string CoverImageUrl { get; set; }
        public string BrandName { get; set; }

    }
}
