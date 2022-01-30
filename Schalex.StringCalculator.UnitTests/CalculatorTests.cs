using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Schalex.StringCalculator.Core.Interfaces;
using Schalex.StringCalculator.Core.Services;
using Schalex.StringCalculator.Domain;
using Schalex.StringCalculator.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schalex.StringCalculator.UnitTests
{
    [TestClass]
    public class CalculatorTests
    {
        private readonly ICalculator calculator;

        private readonly Mock<IInputSanitizer> sanitizerMock = new Mock<IInputSanitizer>();
        private readonly Mock<IInputValidator> validatorMock = new Mock<IInputValidator>();
        private readonly Mock<IShuntingYardConverter> converterMock = new Mock<IShuntingYardConverter>();

        public CalculatorTests()
        {
            calculator = new Calculator(sanitizerMock.Object, validatorMock.Object, converterMock.Object);
        }

        [TestMethod]
        public void Calculate_ShouldSucced_OnValid_AdditionOperation()
        {
            // Arrange
            var rawInput = "1+1";
            var input = new StringInput(rawInput);
            input.SetSanitizedInput(rawInput);
            var rpnQueue = new Queue<string>(3);
            rpnQueue.Enqueue("1"); rpnQueue.Enqueue("1"); rpnQueue.Enqueue("+");

            sanitizerMock.Setup(s => s.Sanitize(input)).Returns(input);
            validatorMock.Setup(v => v.Validate(input)).Returns(true);
            converterMock.Setup(c => c.Convert(input)).Returns(rpnQueue);

            // Act
            var result = calculator.Calculate(input);

            // Assert
            result.Should().Be(2);
        }

        [TestMethod]
        public void Calculate_ShouldSucced_OnValid_SubstractionOperation()
        {
            // Arrange
            var rawInput = "1-1";
            var input = new StringInput(rawInput);
            input.SetSanitizedInput(rawInput);
            var rpnQueue = new Queue<string>(3);
            rpnQueue.Enqueue("1"); rpnQueue.Enqueue("1"); rpnQueue.Enqueue("-");

            sanitizerMock.Setup(s => s.Sanitize(input)).Returns(input);
            validatorMock.Setup(v => v.Validate(input)).Returns(true);
            converterMock.Setup(c => c.Convert(input)).Returns(rpnQueue);

            // Act
            var result = calculator.Calculate(input);

            // Assert
            result.Should().Be(0);
        }

        [TestMethod]
        public void Calculate_ShouldSucced_OnValid_AdditionAndSubstractionOperation()
        {
            // Arrange
            var rawInput = "1+1-1";
            var input = new StringInput(rawInput);
            input.SetSanitizedInput(rawInput);
            var rpnQueue = new Queue<string>(5);
            rpnQueue.Enqueue("1"); rpnQueue.Enqueue("1"); rpnQueue.Enqueue("+"); rpnQueue.Enqueue("1"); rpnQueue.Enqueue("-");

            sanitizerMock.Setup(s => s.Sanitize(input)).Returns(input);
            validatorMock.Setup(v => v.Validate(input)).Returns(true);
            converterMock.Setup(c => c.Convert(input)).Returns(rpnQueue);

            // Act
            var result = calculator.Calculate(input);

            // Assert
            result.Should().Be(1);
        }

        [TestMethod]
        public void Calculate_ShouldThrowOperationNotSupportedException_OnUndefinedOperation()
        {
            // Arrange
            var rawInput = "1 / 1";
            var input = new StringInput(rawInput);
            input.SetSanitizedInput(rawInput);
            var rpnQueue = new Queue<string>(3);
            rpnQueue.Enqueue("1"); rpnQueue.Enqueue("1"); rpnQueue.Enqueue("/");

            sanitizerMock.Setup(s => s.Sanitize(input)).Returns(input);
            validatorMock.Setup(v => v.Validate(input)).Returns(true);
            converterMock.Setup(c => c.Convert(input)).Returns(rpnQueue);

            // Act
            Action calculateAction = () =>
            {
                calculator.Calculate(input);
            };

            // Assert
            calculateAction.Should().Throw<UnsupportedOperationException>();
        }
    }
}
