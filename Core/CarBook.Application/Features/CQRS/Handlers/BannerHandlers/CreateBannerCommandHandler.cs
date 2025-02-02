﻿using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Features.CQRS.Commands.BannerComands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class CreateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public CreateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handler(CreateBannerCommand command)
        {
            await _repository.CreateAsync(new Banner
            {
                 Description = command.Description,
                 Title = command.Title,
                 VideoUrl = command.VideoUrl,
                 VideoDescription = command.VideoDescription,
            });
        }
    }
}
