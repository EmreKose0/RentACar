using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarRepositories
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

        public  List<Car> GetCarsListWithBrand()
        {
            var values =  _context.Cars.Include(X=>X.Brand).ToList();
            return values;
        }

        

        public List<Car> GetLast5CarsWithBrand()
        {
            var value = _context.Cars.Include(x => x.Brand).OrderByDescending(i => i.CarID).Take(5).ToList();
            return value;
        }
    }
}
