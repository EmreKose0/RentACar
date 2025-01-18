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
    public class GetCarBrandAndModelByRentPriceMaxQueryHandler : IRequestHandler<GetCarBrandAndModelByRentPriceMaxQuery, GetCarBrandAndModelByRentPriceMaxQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarBrandAndModelByRentPriceMaxQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarBrandAndModelByRentPriceMaxQueryResult> Handle(GetCarBrandAndModelByRentPriceMaxQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarBrandAndModelByRentPriceMax();
            return new GetCarBrandAndModelByRentPriceMaxQueryResult
            {
                CarBrandAndModelByRentPriceMax = value
            };

        }
    }
}
