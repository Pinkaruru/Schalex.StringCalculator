using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Schalex.StringCalculator.Core.Interfaces;
using Schalex.StringCalculator.Core.Services;
using Schalex.StringCalculator.Domain;
using Schalex.StringCalculator.Domain.Exceptions;
using System;

namespace chalex.Maersk.CodingExercise.StringCalculator.Tests
{
    [TestClass]
    public class InputValidatorTests
    {
        private readonly IInputValidator inputValidator;

        public InputValidatorTests()
        {
            this.inputValidator = new InputValidator();
        }

        [TestMethod]
        public void Validate_Should_Succed_OnInputContainingWhiteListedCharacters()
        {
            // Arrange
            var rawInput = "1+1-6";
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
            var rawInput = "1+1-6";
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
        public void Validate_Should_ThrowInvalidInputCharactersException_OnInputContainingComma()
        {
            // Arrange
            var rawInput = "0,1";
            var input = new StringInput(rawInput);
            input.SetSanitizedInput(rawInput);

            // Act
            Action validateAction = () =>
            {
                var result = inputValidator.Validate(input);
            };

            // Assert
            validateAction.Should().Throw<InvalidInputCharactersException>();
        }

        [TestMethod]
        public void Validate_Should_ThrowInvalidInputCharactersException_OnInputContainingLatinCharacters()
        {
            // Arrange
            var rawInput = "1+2a";
            var input = new StringInput(rawInput);
            input.SetSanitizedInput(rawInput);

            // Act
            Action validateAction = () =>
            {
                var result = inputValidator.Validate(input);
            };

            // Assert
            validateAction.Should().Throw<InvalidInputCharactersException>();
        }

        [TestMethod]
        public void Validate_Should_ThrowArgumentNullException_OnInputBeingNull()
        {
            // Arrange
            StringInput? input = null;

            // Act
            Action validateAction = () =>
            {
#pragma warning disable CS8604 // Possible null reference argument.
                var result = inputValidator.Validate(input);
#pragma warning restore CS8604 // Possible null reference argument.
            };

            // Assert
            validateAction.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void Validate_Should_ThrowArgumentException_OnInputBeingEmpty()
        {
            // Arrange
            StringInput? input = new StringInput(string.Empty);

            // Act
            Action validateAction = () =>
            {
                var result = inputValidator.Validate(input);
            };

            // Assert
            validateAction.Should().Throw<ArgumentException>();
        }

        [TestMethod]
        public void Validate_Should_ThrowInvalidInputCharactersException_OnInputContainingMultiplication()
        {
            // Arrange
            var rawInput = "2*2";
            var input = new StringInput(rawInput);
            input.SetSanitizedInput(rawInput);

            // Act
            Action validateAction = () =>
            {
                var result = inputValidator.Validate(input);
            };

            // Assert
            validateAction.Should().Throw<InvalidInputCharactersException>();
        }

        [TestMethod]
        public void Validate_Should_ThrowInvalidInputCharactersException_OnInputContainingDivision()
        {
            // Arrange
            var rawInput = "2/2";
            var input = new StringInput(rawInput);
            input.SetSanitizedInput(rawInput);

            // Act
            Action validateAction = () =>
            {
                var result = inputValidator.Validate(input);
            };

            // Assert
            validateAction.Should().Throw<InvalidInputCharactersException>();
        }

        [TestMethod]
        public void Validate_Should_ThrowInvalidInputStructureException_OnInputStartingWithOperator()
        {
            // Arrange
            var rawInput = "+2+2";
            var input = new StringInput(rawInput);
            input.SetSanitizedInput(rawInput);

            // Act
            Action validateAction = () =>
            {
                var result = inputValidator.Validate(input);
            };

            // Assert
            validateAction.Should().Throw<InvalidInputStructureException>();
        }

        [TestMethod]
        public void Validate_Should_ThrowInvalidInputStructureException_OnInputEndingWithOperator()
        {
            // Arrange
            var rawInput = "2+2-";
            var input = new StringInput(rawInput);
            input.SetSanitizedInput(rawInput);

            // Act
            Action validateAction = () =>
            {
                var result = inputValidator.Validate(input);
            };

            // Assert
            validateAction.Should().Throw<InvalidInputStructureException>();
        }

        [TestMethod]
        public void Validate_Should_ThrowInvalidInputStructureException_OnInputContainDoubleAllowedOperatorsInOrder()
        {
            // Arrange
            var rawInput = "2++2";
            var input = new StringInput(rawInput);
            input.SetSanitizedInput(rawInput);

            // Act
            Action validateAction = () =>
            {
                var result = inputValidator.Validate(input);
            };

            // Assert
            validateAction.Should().Throw<InvalidInputStructureException>();
        }

    }
}