using AppointmentManagement.Application.Features.AgentAvailability.Queries;
using AppointmentManagement.Application.Features.Agents.Queries;
using AppointmentManagement.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace AppointmentManagement.WebApi.Test
{
    public class AgentAvailabilityControllerTests
    {
        [Test]
        public async Task GetById_Must_Return_OkObjectResultAsync()
        {
            //Arrange

            var mediator = new Mock<IMediator>();
            mediator
                .Setup(m => m.Send(It.IsAny<GetAgentAvailabilityByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new AgentAvailabilityVm()
                {
                    AgentAvailabilityId = 1,
                    AgentDto = new AgentDto()
                    {
                        Id = 1,
                        FirstName = "Test",
                        LastName = "Test",
                        PhoneNumber = "Test",
                    }
                });

            var httpContextHelper = new Mock<IHttpContextHelper>();
            var logger = new Mock<ILogger<AgentAvailabilityController>>();
            var clientController = new AgentAvailabilityController(mediator.Object, httpContextHelper.Object, logger.Object);

            // Act

            var result = await clientController.GetById(1);
            var okResult = result as OkObjectResult;

            //Assert 

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

        }
    }
}
