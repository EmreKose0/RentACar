using CarBook.Application.Interfaces.StatisticsInferfaces;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }

        public string GetBlogTitleByMaxBlogComment()
        {
            var value = _context.Comments
                         .Include(x=>x.Blog)
                         .GroupBy(x => x.BlogID)
                         .Select(group => new
                         {
                             Count = group.Count(),
                             BlogName = group.FirstOrDefault().Blog.Title // BrandName almak için Brand nesnesini kullanıyoruz
                         })
                         .OrderByDescending(z => z.Count)
                         .Take(1)
                         .FirstOrDefault(); // İlk öğeyi alıyoruz, çünkü yalnızca 1 tane sonuç olacak.
            // Eğer value null değilse, BrandName döndürüyoruz
            
            return value.BlogName;
        }

        public string GetBrandNameByMaxCar()
        {

            var value = _context.Cars
             .Include(y => y.Brand)
             .GroupBy(x => x.BrandID)
             .Select(group => new
             {
                 Count = group.Count(),
                 BrandName = group.FirstOrDefault().Brand.Name // BrandName almak için Brand nesnesini kullanıyoruz
             })
             .OrderByDescending(z => z.Count)
             .Take(1)
             .FirstOrDefault(); // İlk öğeyi alıyoruz, çünkü yalnızca 1 tane sonuç olacak.

            // Eğer value null değilse, BrandName döndürüyoruz
            return value?.BrandName; 
        }

        public int GetAuthorCount()
        {
            var values = _context.Authors.Count();
            return values;
        }

        public decimal GetAvgRentPriceForDaily()
        {
            var id = _context.Pricings.Where(x => x.Name == "Günlük").Select(s=>s.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amount);
            return value;

        }

       

        public int GetBlogCount()
        {
            var values = _context.Blogs.Count();
            return values;
        }

        public int GetBrandCount()
        {
            var values = _context.Brands.Count();
            return values;
        }

        public string GetCarBrandAndModelByRentPriceMax()
        {
            int pricingId =  _context.Pricings.Where(x=>x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(z=>z.PricingID ==pricingId).Max(x=> x.Amount);
            int carId = _context.CarPricings.Where(x=>x.Amount == amount).Select(y=>y.CarID).FirstOrDefault();
            string brandModel = _context.Cars.Where(x=>x.CarID == carId).Include(y=>y.Brand).Select(z=>z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandModel;
        }

        public string GetCarBrandAndModelByRentPriceMin()
        {
            int pricingId = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(z => z.PricingID == pricingId).Min(x => x.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarID).FirstOrDefault();
            string brandModel = _context.Cars.Where(x => x.CarID == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandModel;
        }

        public int GetCarCount()
        {
            var values = _context.Cars.Count();
            return values;
        }

        public int GetCarCountByFuelElectric()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Elektrik").Count();
            return value;
        }

        public int GetCarCountByFuelGasOrDiesel()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
            return value;
        }

        public int GetCarCountByKmUnder1000()
        {
            var values = _context.Cars.Where(x => x.Km < 1000).Count();
            return values;
        }

        public int GetCarCountByTransmissionIsAuto()
        {
            var value = _context.Cars.Where(x => x.Transmission == "Otomatik").Count();
            return value;
        }

        public int GetLocationCount()
        {
            var values = _context.Locations.Count();
            return values;
        }

        decimal IStatisticsRepository.GetAvgRentPriceForMonthly()
        {
            var id = _context.Pricings.Where(x => x.Name == "Aylık").Select(s => s.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amount);
            return value;
        }

        decimal IStatisticsRepository.GetAvgRentPriceForWeekly()
        {
            var id = _context.Pricings.Where(x => x.Name == "Haftalık").Select(s => s.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amount);
            return value;
        }
    }
}
