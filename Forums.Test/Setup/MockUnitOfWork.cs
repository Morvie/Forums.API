using ForumsService.Application.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forums.Test.Setup
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockLeaveTypeRepo = MockForumRepository.GetForumsRepository();

            mockUow.Setup(r => r.QueryForumRepository).Returns(mockLeaveTypeRepo.Object);

            return mockUow;
        }
    }
}
