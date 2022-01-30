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
    public class ShuntingYardConverterTests
    {
        private readonly IShuntingYardConverter converter;
        public ShuntingYardConverterTests()
        {
            converter = new ShuntingYardConverter();
        }

        [TestMethod]
        public void Convert_ShouldThrowArgumentNullException_OnInputNull()
        {
            // Arrange
            StringInput input = null;

            // Act
            Action convertAction = () =>
            {
                var result = converter.Convert(input);
            };

            // Assert
            convertAction.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void Convert_ShouldThrowArgumentException_OnInputNotSanitized()
        {
            // Arrange
            StringInput input = new StringInput("1+   1");

            // Act
            Action convertAction = () =>
            {
                var result = converter.Convert(input);
            };

            // Assert
            convertAction.Should().Throw<ArgumentException>();
        }

        [TestMethod]
        public void Convert_ShouldSetOperationStringInInfix_ToRPNQueue()
        {
            // Arrange
            var input = new StringInput("");
            input.SetSanitizedInput("1+3-2");

            // Act
            var rpnQueue = converter.Convert(input);
            var rpnString = string.Join("", rpnQueue);

            // Assert
            rpnString.Should().Be("13+2-");
        }
    }
}
