using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.StatisticDtos
{
    public class ResultStatisticsDto
    {
        public int carCount { get; set; }
        public int locationCount { get; set; }
        public int authorCount {  get; set; }
        public int blogCount { get; set; }
        public int brandCount { get; set; } 
        public decimal avgRentPriceForDaily { get; set; }
        public decimal avgRentPriceForWeekly { get; set; }
        public decimal avgRentPriceForMonthly { get; set; }
        public int carCountByTransmissionIsAuto { get; set; }
        public string brandNameByMaxCar { get; set; }
        public int carCountByKmUnder1000 { get; set; }
        public int carCountByFuelGasOrDiesel { get; set; }
        public int carCountByFuelElectric { get; set; }
        public string carBrandAndModelByRentPriceMax { get; set; }
        public string carBrandAndModelByRentPriceMin { get; set; }
        public string blogTitleByMaxBlogComment { get; set; }

    }
}
