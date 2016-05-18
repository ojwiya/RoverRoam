using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
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
    public class RoverServiceTest
    {
        private IFixture _fixture;
        private Mock<IRoverService> _mockRoverService;
        private IRoverService _RoverService;
        private string[] _roverResult;

        private string _plateauSize;
        private Instruction[] _instructions;
        
        [SetUp]
        public void SetupTests()
        {
            _fixture = new Fixture().Customize(new MultipleCustomization());

            _RoverService = new RoverService();

            _plateauSize = "5 5";

           _instructions = new Instruction[] {
                                    new Instruction(){ 
                                        StartPosition="1 2 N",
                                        Movements = "LMLMLMLMM",
                                         RoverId = 0
                                        },
                                    new Instruction(){ 
                                        StartPosition="3 3 E",
                                        Movements = "MMRMMRMRRM",
                                        RoverId = 0
                                        }
                                 };

        }
        
        [Test]
        public void Rover_ShouldRoam_As_Instructed()
        {
            // Arrange
            // Act
            // Assert

            _roverResult = _RoverService.Roam(_plateauSize,_instructions);

            Assert.IsNotNull(_roverResult);
            Assert.AreNotEqual(0, _roverResult.Count());
            Assert.AreEqual("1 3 N", _roverResult[0]);
            Assert.AreEqual("5 1 E", _roverResult[1]);



        }

        
    }
}
