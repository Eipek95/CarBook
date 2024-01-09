namespace CarBook.Dto.StatisticsDtos
{

    public class ResultStatisticsDto
    {
        public int carCount { get; set; }
        public int locationCount { get; set; }
        public int authorCount { get; set; }
        public int blogCount { get; set; }
        public int brandCount { get; set; }
        public decimal avgPriceForDaily { get; set; }
        public decimal avgPriceForWeekly { get; set; }
        public decimal avgRentPriceForMonthly { get; set; }
        public int carCountByTranmissionIsAuto { get; set; }
        public int carCountByKmSmallerThen1000 { get; set; }
        public int gasolineCount { get; set; }
        public int dieselCount { get; set; }
        public int carCountByFuelElectric { get; set; }
        public string carBrandAndModelByRentPriceDailyMax { get; set; }
    }
}


