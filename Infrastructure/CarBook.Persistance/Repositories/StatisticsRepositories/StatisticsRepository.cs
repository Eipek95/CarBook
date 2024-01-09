using CarBook.Application.Interfaces.StatisticsInterfaces;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistance.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }

        public int GetAuthorCount() => _context.Authors.Count();


        public decimal GetAvgRentPriceForDaily()
        {
            int rentId = _context.Pricings.Where(p => p.Name.ToLower().Contains("Günlük".ToLower())).Select(i => i.PricingID).FirstOrDefault();
            var result = _context.CarPricings.Where(x => x.PricingID == rentId).Average(x => x.Amount);
            return result;
        }

        public decimal GetAvgRentPriceForMonthly()
        {
            int rentId = _context.Pricings.Where(p => p.Name.ToLower().Contains("Aylık".ToLower())).Select(i => i.PricingID).FirstOrDefault();
            var result = _context.CarPricings.Where(x => x.PricingID == rentId).Average(x => x.Amount);
            return result;
        }

        public decimal GetAvgRentPriceForWeekly()
        {
            int rentId = _context.Pricings.Where(p => p.Name.ToLower().Contains("Haftalık".ToLower())).Select(i => i.PricingID).FirstOrDefault();
            var result = _context.CarPricings.Where(x => x.PricingID == rentId).Average(x => x.Amount);
            return result;
        }

        public int GetBlogCount() => _context.Blogs.Count();

        public string GetBlogTitleByMaxBlogComment()
        {
            //select top(1) blogid,count(*) as 'sayi' from comments group by blogid order by sayi desc
            var blogId = _context.Comments.GroupBy(x => x.BlogId)
                .Select(y => new
                {
                    BlogId = y.Key,
                    Count = y.Count()
                }).OrderByDescending(z => z.Count).Take(1).Select(t => t.BlogId).FirstOrDefault();
            string blogName = _context.Blogs.Where(x => x.BlogID == blogId).Select(x => x.Title).FirstOrDefault()!;
            return blogName;
        }

        public int GetBrandCount() => _context.Brands.Count();

        public string GetBrandNameByMaxCar()
        {

            //select top(1) brands.name,count(*) as 'toplamarac' from cars inner join brands on cars.brandid=brands.brandid group by brands.name order by toplamarac des

            var brandId = _context.Cars.GroupBy(x => x.BrandId)
                              .Select(y => new
                              {
                                  BrandId = y.Key,
                                  Count = y.Count()
                              }).OrderByDescending(z => z.Count).Take(1).Select(t => t.BrandId).FirstOrDefault();

            string brandName = _context.Brands.Where(x => x.BrandID == brandId).Select(x => x.Name).FirstOrDefault()!;
            return brandName;
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            //select*from carpricings where amount=(select max(amount) from carpricings where pricingid=3)
            int pricingId = _context.Pricings.Where(x => x.Name.ToLower() == "Günlük".ToLower()).Select(x => x.PricingID).FirstOrDefault();
            decimal price = _context.CarPricings.Where(x => x.PricingID == pricingId).Max(x => x.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == price).Select(y => y.CarID).FirstOrDefault();
            string brandModel = _context.Cars.Where(x => x.CarId == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandModel;
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            int pricingId = _context.Pricings.Where(x => x.Name.ToLower() == "Günlük".ToLower()).Select(x => x.PricingID).FirstOrDefault();
            decimal price = _context.CarPricings.Where(x => x.PricingID == pricingId).Min(x => x.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == price).Select(y => y.CarID).FirstOrDefault();
            string brandModel = _context.Cars.Where(x => x.CarId == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandModel;
        }

        public int GetCarCount() => _context.Cars.Count();

        public int GetCarCountByFuelElectric() => _context.Cars.Where(x => x.Fuel == "Elektrik").Count();

        public (int, int) GetCarCountByFuelGasolineOrDiesel()
        {
            var fuelGasolineCount = _context.Cars.Where(x => x.Fuel == "Benzin").Count();
            var fuelDieselCount = _context.Cars.Where(x => x.Fuel == "Dizel").Count();

            return (fuelDieselCount, fuelGasolineCount);
        }

        public int GetCarCountByKmSmallerThen1000() => _context.Cars.Where(x => x.Km <= 1000).Count();

        public int GetCarCountByTranmissionIsAuto() => _context.Cars.Where(x => x.Transmission == "Otomatik").Count();

        public int GetLocationCount() => _context.Locations.Count();
    }
}
