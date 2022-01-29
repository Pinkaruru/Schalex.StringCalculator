using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schalex.StringCalculator.Core.Interfaces;
using Schalex.StringCalculator.Core.Services;
using Schalex.StringCalculator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schalex.StringCalculator.UnitTests
{
    [TestClass]
    public class InputSanitizerTests
    {
        private readonly IInputSanitizer inputSanitizer;

        public InputSanitizerTests()
        {
            this.inputSanitizer = new InputSanitizer();
        }

        [TestMethod]
        public void Sanitize_ShouldRemoveAllWhitespaces()
        {
            // Arrange
            var rawInput = " 1 + 2 ";
            var stringInput = new StringInput(rawInput);

            // Act
            inputSanitizer.Sanitize(ref stringInput);

            // Assert
            stringInput.OriginalInput.Should().BeEquivalentTo("1+2");
        }

        [TestMethod]
        public void Sanitize_ShouldSetStringInputStateToSanitizedTrue()
        {
            // Arrange
            var stringInput = new StringInput("1+2");

            // Act
            inputSanitizer.Sanitize(ref stringInput);

            // Assert
            stringInput.IsSanitized.Should().BeTrue();
        }
    }
}
