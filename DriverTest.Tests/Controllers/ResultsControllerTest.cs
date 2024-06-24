using System;
using System.Threading.Tasks;
using AutoFixture;
using DriverTest.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace DriverTest.Tests.Controllers;


public class ResultsControllerTest
{
    private static Fixture fixture = new Fixture();

    [Fact]
    public async Task ShouldReturnOk_WhenResultNotExistInDatabase()
    {
        // Arrange 
        var result = fixture.Create<Models.Results>();
        
        var mockLogger = new Mock<ILogger<ResultsController>>();
        var repository = new Mock<IResultRepositories>();
        
        var controller = new ResultsController(repository.Object, mockLogger.Object);
        
        // Act
        var response = await controller.PostResults(result);
        
        // Assert
        response.Result.Should().NotBeNull();
        response.Result.Should().BeOfType<CreatedAtActionResult>();
        var objectResult = (CreatedAtActionResult)response.Result!;
        objectResult.StatusCode.Should().Be(StatusCodes.Status201Created);
    }  
    
    [Fact]
    public async Task ShouldSaveResult_WhenNotExistInDatabase()
    {
        // Arrange 
        var result = fixture.Create<Models.Results>();
        
        var mockLogger = new Mock<ILogger<ResultsController>>();
        var repository = new Mock<IResultRepositories>();
        repository.Setup(x => x.CheckResultsExist(result.Id)).Returns(true);
        
        var controller = new ResultsController(repository.Object, mockLogger.Object);
        
        // Act
        var response = await controller.PostResults(result);
        
        // Assert
        response.Result.Should().NotBeNull();
        response.Result.Should().BeOfType<BadRequestObjectResult>();
        var objectResult = (BadRequestObjectResult)response.Result!;
        objectResult.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
    }  
}