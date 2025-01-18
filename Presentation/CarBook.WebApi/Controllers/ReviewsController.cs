using CarBook.Application.Features.Mediator.Commands.ReservationCommands;
using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using CarBook.Application.Features.Mediator.Queries.ReviewQueries;
using CarBook.Application.Features.Mediator.Results.ReviewResults;
using CarBook.Application.Validators.ReviewValidators;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ReviewsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> ReviewListByCarId (int id)
		{
			var value = await _mediator.Send(new GetReviewByCarIDQuery(id));
			return Ok(value);
		}

		

		[HttpPost]
		public async Task<IActionResult> CreateReview(CreateReviewCommand command)
		{
			CreateReviewValidator validator = new CreateReviewValidator();
			var validationResult = validator.Validate(command);

			if(!validationResult.IsValid)
			{
				return BadRequest(ModelState);
			}
			await _mediator.Send(command);
			return Ok("Review is added..");
		}


		[HttpPut]
		public async Task<IActionResult> UpdateReview(UpdateReviewCommand updateReview)
		{
			await _mediator.Send(updateReview);
			return Ok("Review is Updated");
		}
	}
}
