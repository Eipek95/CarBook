using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.ViewModels;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistance.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<CarPricing> GetCarPricingWithCars()
        {
            var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(z => z.Pricing).Where(x => x.PricingID == 4).ToList();
            return values;
        }

        public List<CarPricingViewModel> GetCarPricingWithTimePeriod()
        {

            List<CarPricingViewModel> result = new List<CarPricingViewModel>();

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "Select* from(select Model, CoverImageUrl,PricingID, Amount from CarPricings inner join cars on cars.CarId= CarPricings.CarID inner join brands on brands.BrandID= Cars.BrandId) as SourceTable Pivot(Sum(Amount) for PricingID In ([4], [5], [7])) as PivotTable;";
                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CarPricingViewModel model = new CarPricingViewModel()
                        {
                            Model = reader["Model"].ToString(),
                            CoverImageUrl = reader["CoverImageUrl"].ToString(),
                            Amounts = new List<decimal>
                            {
                                Convert.ToDecimal(reader[2]),
                                Convert.ToDecimal(reader[3]),
                                Convert.ToDecimal(reader[4])
                            }
                        };

                        result.Add(model);
                    }
                }
                _context.Database.CloseConnection();
                return result;
            }


            //using (var dbContext = new CarBookContext())
            //{
            //    result = dbContext.CarPricings
            //        .Join(dbContext.Cars, cp => cp.CarID, c => c.CarId, (cp, c) => new { cp, c })
            //        .Join(dbContext.Brands, cc => cc.c.BrandId, b => b.BrandID, (cc, b) => new { cc.cp, cc.c, b })
            //        .GroupBy(x => new { x.c.Model, x.cp.PricingID })
            //        .Select(g => new CarPricingViewModel
            //        {
            //            PricingID = g.Key.PricingID,
            //            CarID = g.First().c.CarId,
            //            Amount = g.Sum(x => x.cp.Amount),
            //            Model = g.First().c.Model,
            //            BrandName = g.First().b.Name,
            //            ImageUrl = g.First().c.CoverImageUrl
            //        })
            //        .OrderBy(x => x.PricingID & x.CarID).ToList();
            //}



        }
    }
}
