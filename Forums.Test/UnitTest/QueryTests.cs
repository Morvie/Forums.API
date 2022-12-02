using Forums.Test.Setup;
using ForumsService.Application.Interface;
using ForumsService.Application.Query.GetAllForums;
using ForumsService.Application.Query.GetForum;
using ForumsService.Domain.Entities;
using Moq;


namespace Forums.Test.UnitTest
{
    public class QueryTests
    {
        private readonly Mock<IQueryForumRepository> _mockRepo;
        public QueryTests() => _mockRepo = MockForumRepository.GetForumsRepository();

        [Fact]
        public async Task GetAllForums()
        {
            //Arrange
            var handler = new CreateForumHandler(_mockRepo.Object);

            //Act
            var result = await handler.Handle(new GetAllForumsQuery(), CancellationToken.None);

            //Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetSingleForum()
        {
            //Arrange
            var handler = new GetForumHandler(_mockRepo.Object);
            var expected = new ForumsDTO() { Id = new Guid("208e2274-db97-4ac4-b17c-27d10abca7a8"), Title = "Harry Potter & The Deathly Hallows Part 1 - Hagrid?!", Description = "Just Hagrid in the movie?!.", Amountoflikes = 245, DateOfAdded = DateTime.MaxValue, MovieId = 5345, Ownership = new Guid("48aff7a7-702c-40d7-bbb0-417c0d775c08"), Reported = false };

            //Act
            var result = await handler.Handle(new GetForumQuery(new Guid("208e2274-db97-4ac4-b17c-27d10abca7a8")), CancellationToken.None);

            //Assert
            Assert.Equal(expected.ToString(), result.ToString());
        }

        [Fact]
        public async Task GetSingleForum_WithoutId()
        {
            //Arrange
            var handler = new GetForumHandler(_mockRepo.Object);
            var expected = new ForumsDTO() { Id = new Guid("208e2274-db97-4ac4-b17c-27d10abca7a8"), Title = "Harry Potter & The Deathly Hallows Part 1 - Hagrid?!", Description = "Just Hagrid in the movie?!.", Amountoflikes = 245, DateOfAdded = DateTime.MaxValue, MovieId = 5345, Ownership = new Guid("48aff7a7-702c-40d7-bbb0-417c0d775c08"), Reported = false };

            //Act
            var result = await handler.Handle(new GetForumQuery(new Guid()), CancellationToken.None);

            //Assert
            Assert.Null(result);
        }
    }
}
