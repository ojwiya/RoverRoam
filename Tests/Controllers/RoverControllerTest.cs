using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Api;
using Api.Controllers;
using Moq;
using NUnit;
using Core.Interfaces;
using NUnit.Framework;
using Core.Models;
using Core.Services;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;

namespace Tests
{
    [TestFixture]
    public class RoverControllerTest
    {
        private IFixture _fixture;
        private Mock<IRoverService> _mockRoverService;
        private string[] _roverResult;
        private RoverController _controller;
        
        [SetUp]
        public void SetupTests()
        {
            _fixture = new Fixture().Customize(new MultipleCustomization());
            
            _mockRoverService = new Mock<IRoverService>();

            _controller = new RoverController(_mockRoverService.Object);

            _roverResult = _fixture.Create<string[]>();

            _mockRoverService.Setup(m => m.Roam(It.IsAny<string>(),It.IsAny<Instruction[]>()))
                .Returns((string[] r) => { return _roverResult; });
        }
        
        [Test]
        public void Roam_Should_Return_RoverPositions()
        {
            Assert.IsNotNull(_roverResult);
            Assert.AreNotEqual(0, _roverResult.Count());

        }

        
    }
}
