using Schalex.StringCalculator.Core.Interfaces;
using Schalex.StringCalculator.Domain;
using Schalex.StringCalculator.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace Schalex.StringCalculator.Core.Services
{
    public class InputValidator : IInputValidator
    {
        public const string AllowedCharacters = "0123456789+-";
        public const string AllowedStructurePattern = @"^(\d+)([+-]\d+)*$";

        public InputValidator()
        {
            regex = new Regex(AllowedStructurePattern);
        }

        private readonly Regex regex;

        public bool Validate(StringInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            if (!input.IsSanitized)
            {
                throw new ArgumentException($"{nameof(input)} is not sanitized");
            }

            if (string.IsNullOrWhiteSpace(input.SanitizedInput))
            {
                throw new InvalidInputCharactersException($"{nameof(input.SanitizedInput)} can't be null, empty or only containing whitespaces");
            }

            var validateCharactersResult = ValidateCharacters(input.SanitizedInput);
            if (!validateCharactersResult)
            {
                
                throw new InvalidInputCharactersException($"{nameof(input.SanitizedInput)} contains invalid characters. Allowed characters: {AllowedCharacters}");
            }

            var validateStructureResult = ValidateStructure(input.SanitizedInput);
            if (!validateStructureResult)
            {
                throw new InvalidInputStructureException($"{nameof(input.SanitizedInput)} has invalid structure. Valid structure examples: 10+1, 30-5, 10-5+15, ...");
            }

            return validateCharactersResult && validateStructureResult;
        }

        private bool ValidateCharacters(string input)
        {
            for(int i = 0; i < input.Length; i++)
            {
                if (!AllowedCharacters.Contains(input[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private bool ValidateStructure(string input)
        {
            return regex.IsMatch(input);
        }
    }
}
