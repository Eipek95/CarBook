using CarBook.Application.Interfaces.CarPricingInterfaces;
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
    }
}
