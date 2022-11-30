using AutoMapper;
using Forums.Controllers;
using Forums.Models;
using ForumsService.Application.Command.CreateForum;
using ForumsService.Domain.Entities;
using ForumsService.Infrastructure.Repository;
using MediatR;
using Microsoft;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forums.Test.IntegrationTest
{
    public class ForumsRepositoryTests
    {
        [Fact]
        public async Task ReturnJsonResult()
        {
            var mediator = new Mock<IMediator>();
            var command = new CreateForumCommand("Title","Description",new Guid(),DateTime.Now,false,1346,54326);
            var calculatePriceResult = new ForumsDTO { Id= new Guid(), DateOfAdded = DateTime.Now, Description = "Test", Amountoflikes = 123, MovieId = 2364,Ownership= new Guid(), Reported = false, Title ="Hello!"};
            mediator.Setup(x => x.Send(command, default(CancellationToken))).ReturnsAsync(calculatePriceResult);
            var controller = new ForumController(mediator.Object);

            var result = await controller.Create(command);

            Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.Equal(calculatePriceResult, ((OkObjectResult)result).Value);
        }

        [Fact]
        public async Task CallMediatorWithCorrectParameters()
        {
            var mediator = new Mock<IMediator>();
            var command = new CreateForumCommand("Title", "Description", new Guid(), DateTime.Now, false, 1346, 54326);
            var controller = new ForumController(mediator.Object);

            await controller.Create(command);

            mediator.Verify(x => x.Send(command, default(CancellationToken)), Times.Once());
        }
    }
}
