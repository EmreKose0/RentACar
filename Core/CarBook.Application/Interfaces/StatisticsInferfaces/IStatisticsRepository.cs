using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.StatisticsInferfaces
{
    public interface IStatisticsRepository
    {
        int GetCarCount();
        int GetLocationCount();
        int GetAuthorCount();
        int GetBrandCount();
        int GetBlogCount();
        decimal GetAvgRentPriceForDaily();
        decimal GetAvgRentPriceForWeekly();
        decimal GetAvgRentPriceForMonthly();
        int GetCarCountByTransmissionIsAuto();
        string GetBrandNameByMaxCar();
        string GetBlogTitleByMaxBlogComment();
        int GetCarCountByKmUnder1000();
        int GetCarCountByFuelGasOrDiesel();
        int GetCarCountByFuelElectric();
        string GetCarBrandAndModelByRentPriceMax();
        string GetCarBrandAndModelByRentPriceMin();

    }
}
