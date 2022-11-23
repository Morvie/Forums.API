using Forums.Test.Model.Testing;
using ForumsService.Application.Interface;
using ForumsService.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forums.Test.Setup
{
    public interface IGuidService { Guid NewGuid(); }
    public static class MockForumRepository
    {
        public static Mock<IQueryForumRepository> GetForumsRepository()
        {
            var mockGuidService = new Mock<IGuidService>();

            var forumstypes = new List<ForumsDTO>
            {
                new ForumsDTO() { Id = new Guid("1c565daf-3eaa-4b60-bc11-d0a96fce249e"), Title = "Is the Star-Wars - Rise of Empire movie good?", Description = "I don't think this is a good movie at all! It contains a lot of bad filming.", Amountoflikes = 4, DateOfAdded = DateTime.Now, MovieId = 42543, Ownership = new Guid("1c565daf-3eaa-4b60-bc11-d0a96fce249e"), Reported = false },
                new ForumsDTO() { Id = new Guid("208e2274-db97-4ac4-b17c-27d10abca7a8"), Title = "Harry Potter & The Deathly Hallows Part 1 - Hagrid?!", Description = "Just Hagrid in the movie?!.", Amountoflikes = 245, DateOfAdded = DateTime.MaxValue, MovieId = 5345, Ownership = new Guid("48aff7a7-702c-40d7-bbb0-417c0d775c08"), Reported = false }
            };

            var mockRepo = new Mock<IQueryForumRepository>();
            
            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(forumstypes);
            mockRepo.Setup(r => r.Get(new Guid("208e2274-db97-4ac4-b17c-27d10abca7a8"))).ReturnsAsync(new ForumsDTO{ Id = new Guid("208e2274-db97-4ac4-b17c-27d10abca7a8"), Title = "Harry Potter & The Deathly Hallows Part 1 - Hagrid?!", Description = "Just Hagrid in the movie?!.", Amountoflikes = 245, DateOfAdded = DateTime.MaxValue, MovieId = 5345, Ownership = new Guid("48aff7a7-702c-40d7-bbb0-417c0d775c08"), Reported = false });

            return mockRepo;

        }
        public static Mock<ICommandForumRepository> CommandForumRepository()
        {
            var mockGuidService = new Mock<IGuidService>();

            var forumstypes = new List<ForumsDTO>
            {
                new ForumsDTO() { Id = new Guid("1c565daf-3eaa-4b60-bc11-d0a96fce249e"), Title = "Is the Star-Wars - Rise of Empire movie good?", Description = "I don't think this is a good movie at all! It contains a lot of bad filming.", Amountoflikes = 4, DateOfAdded = DateTime.Now, MovieId = 42543, Ownership = new Guid("1c565daf-3eaa-4b60-bc11-d0a96fce249e"), Reported = false },
                new ForumsDTO() { Id = new Guid("208e2274-db97-4ac4-b17c-27d10abca7a8"), Title = "Harry Potter & The Deathly Hallows Part 1 - Hagrid?!", Description = "Just Hagrid in the movie?!.", Amountoflikes = 245, DateOfAdded = DateTime.MaxValue, MovieId = 5345, Ownership = new Guid("48aff7a7-702c-40d7-bbb0-417c0d775c08"), Reported = false }
            };

            var mockRepo = new Mock<ICommandForumRepository>();

            mockRepo.Setup(x => x.CreateForum(It.IsAny<ForumsDTO>())).ReturnsAsync((ForumsDTO dto) =>
            {
                forumstypes.Add(dto);
                return dto;
            });
           
            return mockRepo;

        }
    }
}
