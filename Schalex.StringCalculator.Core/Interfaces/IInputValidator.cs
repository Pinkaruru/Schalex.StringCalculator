using Schalex.StringCalculator.Domain;

namespace Schalex.StringCalculator.Core.Interfaces
{
    public interface IInputValidator
    {
        bool Validate(StringInput input);
    }
}
