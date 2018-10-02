using System;
using System.Threading.Tasks;

using AutoFixture;
using AutoFixture.AutoNSubstitute;

using FluentAssertions;

using GiftApi.Controllers;
using GiftApi.MediatRRequests;
using GiftApi.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace GiftApi.Tests.Controllers
{
    public class GiftControllerTests
    {
        private readonly IFixture _fixture;

        public GiftControllerTests()
        {
            _fixture = new Fixture().Customize(new AutoNSubstituteCustomization());

            _fixture.Freeze<IMediator>();
        }

        [Fact]
        public async Task GetGiftWillReturnGift()
        {
            // Arrange
            var gift = _fixture.Create<Gift>();

            _fixture.Create<IMediator>()
                .Send(Arg.Is<GetGift>(r => r.Id == gift.Id))
                .Returns(Task.FromResult(gift));

            var sut = _fixture.Create<GiftController>();

            // Act
            var response = await sut.GetGift(gift.Id);

            // Assert
            response.Should().BeEquivalentTo(gift);
        }

        //[Fact]
        //public async Task CreateNewGiftWillReturnCreatedResponse()
        //{
        //    // Arrange
        //    var sut = _fixture.Create<GiftsController>();

        //    // Act
        //    var response = await sut.CreateNewGift();

        //    // Assert
        //    response.Should().BeOfType<CreatedResult>().Which.StatusCode.Should().Be(StatusCodes.Status201Created);
        //}
    }
}