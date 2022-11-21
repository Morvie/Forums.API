using AutoFixture;
using ForumsService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Forums.Test.Model.Testing
{
    public class ForumDTOTest
    {
        private readonly IFixture fixture = new Fixture();

        [Fact]
        public void ConstructorTest()
        {
            //Arrange
            Guid id = fixture.Create<Guid>();
            Guid ownerId = fixture.Create<Guid>();
            string title = "Is the Star-Wars - Rise of Empire movie good?";
            string description = "I don't think this is a good movie at all! It contains a lot of bad filming.";
            int likes = 42543;
            int movieid = 453;
            DateTime datetime = new (2000, 1, 2);

            ForumsDTO actual = new(id, title, description, ownerId, datetime, false, likes, movieid);

            //Act
            ForumsDTO expected = new(id, "Is the Star-Wars - Rise of Empire movie good?", "I don't think this is a good movie at all! It contains a lot of bad filming.", ownerId, datetime, false, 42543, 453);

            //Assert
            Assert.NotEqual(expected, actual);
        }
    }
}
