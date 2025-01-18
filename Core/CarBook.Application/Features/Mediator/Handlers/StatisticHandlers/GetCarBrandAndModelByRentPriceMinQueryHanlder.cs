using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using CarBook.Application.Features.Mediator.Results.StatisticResults;
using CarBook.Application.Interfaces.StatisticsInferfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetCarBrandAndModelByRentPriceMinQueryHandler : IRequestHandler<GetCarBrandAndModelByRentPriceMinQuery, GetCarBrandAndModelByRentPriceMinQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarBrandAndModelByRentPriceMinQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarBrandAndModelByRentPriceMinQueryResult> Handle(GetCarBrandAndModelByRentPriceMinQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarBrandAndModelByRentPriceMin();
            return new GetCarBrandAndModelByRentPriceMinQueryResult
            {
                CarBrandAndModelByRentPriceMin = value
            };

        }
    }
}
