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
        private IPositionService _positionService;
        private IRoverService _roverService;
        private string[] _roverResult;

        private string _plateauSize;
        private Instruction[] _instructions;
        
        [SetUp]
        public void SetupTests()
        {
            _fixture = new Fixture().Customize(new MultipleCustomization());

            _positionService = new PositionService();
            _roverService = new RoverService(_positionService);

            _plateauSize = "5 5";

            _instructions = new Instruction[] {
                                    new Instruction(){ 
                                        StartPosition="1 2 N",
                                        Movements = "LMLMLMLMM",
                                         RoverId = 1
                                        },
                                    new Instruction(){ 
                                        StartPosition="3 3 E",
                                        Movements = "MMRMMRMRRM",
                                        RoverId = 2
                                        }
                                 };

        }
        
        [Test]
        public void Rover_ShouldRoam_As_Instructed()
        {
            // Arrange
            // Act
            // Assert

            _roverResult = _roverService.Roam(_plateauSize,_instructions);

            Assert.IsNotNull(_roverResult);
            Assert.AreNotEqual(0, _roverResult.Count());
            Assert.AreEqual("1 3 N", _roverResult[0]);
            Assert.AreEqual("5 1 E", _roverResult[1]);
        }

        [Test]
        public void Rover_ShouldMove_North()
        {

            _instructions = new Instruction[] {
                                    new Instruction(){ 
                                        StartPosition="1 1 N",
                                        Movements = "M",
                                        RoverId = 1
                                        }
                                 };
            _roverResult = _roverService.Roam(_plateauSize, _instructions);

            Assert.IsNotNull(_roverResult);
            Assert.AreNotEqual(0, _roverResult.Count());
            Assert.AreEqual("1 2 N", _roverResult[0]);

        }

        [Test]
        public void Rover_ShouldMove_South()
        {


            _instructions = new Instruction[] {
                                    new Instruction(){ 
                                        StartPosition="2 2 S",
                                        Movements = "M",
                                        RoverId = 1
                                        }
                                 };
            _roverResult = _roverService.Roam(_plateauSize, _instructions);

            Assert.IsNotNull(_roverResult);
            Assert.AreNotEqual(0, _roverResult.Count());
            Assert.AreEqual("2 1 S", _roverResult[0]);
        }

        [Test]
        public void Rover_ShouldMove_East()
        {
            _instructions = new Instruction[] {
                                    new Instruction(){ 
                                        StartPosition="1 1 E",
                                        Movements = "M",
                                        RoverId = 1
                                        }
                                 };
            
            _roverResult = _roverService.Roam(_plateauSize, _instructions);

            Assert.IsNotNull(_roverResult);
            Assert.AreNotEqual(0, _roverResult.Count());
            Assert.AreEqual("2 1 E", _roverResult[0]);

        }

        [Test]
        public void Rover_ShouldMove_West()
        {

            _instructions = new Instruction[] {
                                    new Instruction(){ 
                                        StartPosition="1 1 W",
                                        Movements = "M",
                                        RoverId = 1
                                        }
                                 };
            _roverResult = _roverService.Roam(_plateauSize, _instructions);

            Assert.IsNotNull(_roverResult);
            Assert.AreNotEqual(0, _roverResult.Count());
            Assert.AreEqual("0 1 W", _roverResult[0]);

        }

        [Test]
        public void Rover_ShouldRotate_Left()
        {

            _instructions = new Instruction[] {
                                    new Instruction(){ 
                                        StartPosition="1 1 N",
                                        Movements = "L",
                                        RoverId = 1
                                        }
                                 };

            _roverResult = _roverService.Roam(_plateauSize, _instructions);

            Assert.IsNotNull(_roverResult);
            Assert.AreNotEqual(0, _roverResult.Count());
            Assert.AreEqual("1 1 W", _roverResult[0]);

        }


        [Test]
        public void Rover_ShouldRotate_Right()
        {

            _instructions = new Instruction[] {
                                    new Instruction(){ 
                                        StartPosition="1 1 N",
                                        Movements = "R",
                                        RoverId = 1
                                        }
                                 };
            _roverResult = _roverService.Roam(_plateauSize, _instructions);

            Assert.IsNotNull(_roverResult);
            Assert.AreNotEqual(0, _roverResult.Count());
            Assert.AreEqual("1 1 E", _roverResult[0]);

        }

        
    }
}
