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
    public class GetCarCountByFuelGasOrDieselQueryHandler : IRequestHandler<GetCarCountByFuelGasOrDieselQuery, GetCarCountByFuelGasOrDieselQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountByFuelGasOrDieselQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountByFuelGasOrDieselQueryResult> Handle(GetCarCountByFuelGasOrDieselQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountByFuelGasOrDiesel();
            return new GetCarCountByFuelGasOrDieselQueryResult
            {
                CarCountByFuelGasOrDiesel = value
            };

        }
    }
}
