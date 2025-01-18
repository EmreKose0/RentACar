using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.ReviewResults
{
	public class GetReviewByCarIDQueryResult
	{
		public int ReviewID { get; set; }
		public string CustomerName { get; set; }

		public string CustomerImg { get; set; }
		public string Comment { get; set; }
		public int Rate { get; set; }
		public DateTime ReviewDate { get; set; }
		public int CarID { get; set; }
	}
}
