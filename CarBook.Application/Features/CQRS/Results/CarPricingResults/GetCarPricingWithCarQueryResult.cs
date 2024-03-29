﻿namespace CarBook.Application.Features.CQRS.Results.CarPricingResults
{
    public class GetCarPricingWithCarQueryResult
    {
        public int CarPricingID { get; set; }
        public int CarID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Amount { get; set; }
        public string CoverImageUrl { get; set; }
    }
}
