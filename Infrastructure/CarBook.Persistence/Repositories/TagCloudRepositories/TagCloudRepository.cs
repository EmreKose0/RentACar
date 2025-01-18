using CarBook.Application.Interfaces.TagCloudInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.TagCloudRepositories
{
    public class TagCloudRepository : ITagCloudRepository
    {
        private readonly CarBookContext _Context;
public TagCloudRepository(CarBookContext context)
        {
            _Context = context;
        }

        public List<TagCloud> GetTagCloudsByBlogId(int id)
        {
            var values = _Context.TagClouds.Where(x=>x.BlogID == id).ToList();
            return values;
        }
    }
}
