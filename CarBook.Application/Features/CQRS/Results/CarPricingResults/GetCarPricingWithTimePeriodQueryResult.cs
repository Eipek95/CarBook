﻿namespace CarBook.Application.Features.CQRS.Results.CarPricingResults
{
    public class GetCarPricingWithTimePeriodQueryResult
    {

        public string Model { get; set; }
        public decimal DailyAmount { get; set; }
        public decimal WeeklyAmount { get; set; }
        public decimal MonthlyAmount { get; set; }
        public string CoverImageUrl { get; set; }

    }
}
