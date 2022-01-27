using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Schalex.StringCalculator.Core.Interfaces;
using Schalex.StringCalculator.Domain;
using Schalex.StringCalculator.Domain.Exceptions;
using System;

namespace chalex.Maersk.CodingExercise.StringCalculator.Tests
{
    [TestClass]
    public class InputValidatorTests
    {
        private readonly IInputValidator inputValidator;

        public InputValidatorTests(IInputValidator inputValidator)
        {
            this.inputValidator = inputValidator;
        }

        [TestMethod]
        public void Validate_Should_Succed_OnInputContainingWhiteListedCharacters()
        {
            // Arrange
            var rawInput = "1 + 1 - 6";
            var input = new StringInput(rawInput);
            input.SetSanitizedInput(rawInput);

            // Act
            var result = inputValidator.Validate(input);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void Validate_Should_ThrowArgumentException_OnInputNotSanitized()
        {
            // Arrange
            var rawInput = "1 + 1 - 6";
            var input = new StringInput(rawInput);

            // Act
            Action validateAction = () =>
            {
                var result = inputValidator.Validate(input);
            };

            // Assert
            validateAction.Should().Throw<ArgumentException>();
        }

        [TestMethod]
        public void Validate_Should_ThrowArgumentException_OnInputContainingComma()
        {
            // Arrange
            var rawInput = "0, 1";
            var input = new StringInput(rawInput);
            input.SetSanitizedInput(rawInput);

            // Act
            Action validateAction = () =>
            {
                var result = inputValidator.Validate(input);
            };

            // Assert
            validateAction.Should().Throw<ArgumentException>();
        }

        [TestMethod]
        public void Validate_Should_ThrowArgumentException_OnInputContainingLatinCharacters()
        {
            // Arrange
            var rawInput = "1 + 2a";
            var input = new StringInput(rawInput);
            input.SetSanitizedInput(rawInput);

            // Act
            Action validateAction = () =>
            {
                var result = inputValidator.Validate(input);
            };

            // Assert
            validateAction.Should().Throw<ArgumentException>();
        }

        [TestMethod]
        public void Validate_Should_ThrowUnsupportedOperationException_OnInputContainingMultiplication()
        {
            // Arrange
            var rawInput = "2 * 2";
            var input = new StringInput(rawInput);
            input.SetSanitizedInput(rawInput);

            // Act
            Action validateAction = () =>
            {
                var result = inputValidator.Validate(input);
            };

            // Assert
            validateAction.Should().Throw<UnsupportedOperationException>();
        }

        [TestMethod]
        public void Validate_Should_ThrowUnsupportedOperationException_OnInputContainingDivision()
        {
            // Arrange
            var rawInput = "2 / 2";
            var input = new StringInput(rawInput);
            input.SetSanitizedInput(rawInput);

            // Act
            Action validateAction = () =>
            {
                var result = inputValidator.Validate(input);
            };

            // Assert
            validateAction.Should().Throw<UnsupportedOperationException>();
        }
    }
}