﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.AuthorDtos
{
    public class UpdateAuthorDto
    {
        public int AuthorID { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Desciption { get; set; }
    }
}
