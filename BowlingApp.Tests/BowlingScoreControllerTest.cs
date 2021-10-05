using AutoFixture;
using AutoFixture.AutoNSubstitute;
using BowlingApp.Commands;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using BowlingApp.Contracts;
using BowlingApp.Services;

namespace BowlingApp.Tests
{
    public class BowlingScoreControllerTest
    {
        private readonly IFixture _fixture;
        private readonly ICalculateScoreServices _services;

        public BowlingScoreControllerTest()
        {
            _fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
            _services = new CalculateScoreServices();
        }

        [Fact]
        public async Task Handle_Should_Not_Return_Null_When_Command_Created()
        {
            // Arrange
            var getScoreCommand = _fixture.Create<GetScoreCommand>();
            var getScoreCommandHandler = new GetScoreCommandHandler(NullLogger<GetScoreCommandHandler>.Instance);

            // Act
            var result = await getScoreCommandHandler.Handle(getScoreCommand, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.GameCompleted.Should().BeTrue();
        }

        [Fact]
        public void GetActiveNotification_Should_Return_HasActiveNotification_False_When_Empty()
        {
            // Arrange
            var pinsDown = _fixture.Create<List<PinsDown>>();

            // Act
            var data = _services.CalculateScore(pinsDown);

            //Assert
            data.Should().NotBeEmpty();
        }
    }
}
