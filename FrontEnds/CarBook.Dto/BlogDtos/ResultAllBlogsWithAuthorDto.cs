﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.BlogDtos
{
    public class ResultAllBlogsWithAuthorDto
    {
        public int BlogID { get; set; }
        public string Title { get; set; }

        public int AuthorID { get; set; }
        public string CoverImgUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryID { get; set; }
        public string AuthorName { get; set; }

        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string AuthorImgUrl { get; set; }

        public string AuthorDescription { get; set; }

    }
}
