using CarBook.Application.Features.Mediator.Queries.ReviewQueries;
using CarBook.Application.Features.Mediator.Results.ReviewResults;
using CarBook.Application.Interfaces.ReviewInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReviewHandlers
{
	public class GetReviewByCarIDQueryHandler : IRequestHandler<GetReviewByCarIDQuery, List<GetReviewByCarIDQueryResult>>
	{
		private readonly IReviewRepository _repository;

		public GetReviewByCarIDQueryHandler(IReviewRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetReviewByCarIDQueryResult>> Handle(GetReviewByCarIDQuery request, CancellationToken cancellationToken)
		{
			var values =  await _repository.GetReviewsByCarId(request.Id);
			return values.Select(x => new GetReviewByCarIDQueryResult
			{
				CarID = x.CarID,
				Comment = x.Comment,
				ReviewID = x.ReviewID,
				CustomerImg = x.CustomerImg,
				CustomerName = x.CustomerName,
				Rate = x.Rate,
				ReviewDate = x.ReviewDate,
			}).ToList();
		}
	}
}
