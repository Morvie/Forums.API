using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Azure;
using ForumsService.Domain.Entities;
using Xunit;

namespace Forums.Test.Integration.Testing
{
    public class ControllerTesting
    {

        private readonly HttpClient _httpClient = new() { BaseAddress = new Uri("http://localhost:5000") };
        [Fact]
        public async Task DefaultRoute_ReturnsForumsList()
        {
            //Arrange
            var expectedStatusCode = HttpStatusCode.OK;
            var response = await _httpClient.GetAsync("");

            //Act
            var stringResult = await response.Content.ReadAsStringAsync();
            var intResult = int.Parse(stringResult);

            //Assert
            Assert.Equal(expectedStatusCode, response.StatusCode);
            Assert.Equal(2, intResult);
        }
    }
}
