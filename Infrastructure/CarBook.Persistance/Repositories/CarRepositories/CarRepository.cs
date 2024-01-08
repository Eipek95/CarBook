using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistance.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _context;

        public CarRepository(CarBookContext context)
        {
            _context = context;
        }

        public int GetCarCount()
        {
            var value = _context.Cars.Count();
            return value;
        }

        public List<Car> GetCarsListWithBrands()
        {
            return _context.Cars.Include(x => x.Brand).ToList();
        }


        public List<Car> GetLastFiveCarsWithBrands()
        {
            var values = _context.Cars.Include(_x => _x.Brand).ToList().OrderByDescending(x => x.CarId).Take(5).ToList();
            return values;
        }
    }
}
