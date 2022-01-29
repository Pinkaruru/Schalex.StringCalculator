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
        public void Convert_ShouldConvertInput_ToPSN()
        {
            // Arrange
            var input = new StringInput("");
            input.SetSanitizedInput("1+3-2");

            // Act
            var result = converter.Convert(input);

            // Assert
        }

        [TestMethod]
        public void Convert_ShouldSetStringInputState_AfterSuccessfulConversion()
        {
            // Arrange
            var input = new StringInput("");
            input.SetSanitizedInput("1+3-2");

            // Act
            var result = converter.Convert(input);

            // Assert
        }
    }
}
