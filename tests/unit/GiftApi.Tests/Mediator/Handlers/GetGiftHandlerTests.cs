using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Kernel;
using FluentAssertions;
using GiftApi.Mediator.Handlers;
using GiftApi.MediatRRequests;
using GiftApi.Models;
using MediatR;
using Xunit;

namespace GiftApi.Tests.Mediator.Handlers
{
    public class GetGiftHandlerTests
    {
        private readonly IFixture _fixture;

        public GetGiftHandlerTests()
        {
            _fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
        }

        [Fact]
        public async Task SendWillReturnGift()
        {
            // Arrange
            var sut = _fixture.Create<GetGiftHandler>();

            // Act
            var response = await sut.Handle(new GetGift { Id = new Guid("a82aa4b1-45bb-4ecb-a5aa-50de618f2e1d") }, CancellationToken.None);

            // Assert
            response.Should().NotBeNull();
        }
    }
}