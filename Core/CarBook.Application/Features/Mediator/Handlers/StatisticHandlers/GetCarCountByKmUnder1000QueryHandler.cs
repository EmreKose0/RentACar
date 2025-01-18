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
    public class GetCarCountByKmUnder1000QueryHandler : IRequestHandler<GetCarCountByKmUnder1000Query, GetCarCountByKmUnder1000QueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountByKmUnder1000QueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountByKmUnder1000QueryResult> Handle(GetCarCountByKmUnder1000Query request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountByKmUnder1000();
            return new GetCarCountByKmUnder1000QueryResult
            {
                CarCountByKmUnder1000 = value
            };

        }
    }
}
