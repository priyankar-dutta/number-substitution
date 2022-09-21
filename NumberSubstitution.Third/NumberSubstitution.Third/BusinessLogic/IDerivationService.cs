using NumberSubstitution.Third.BusinessLogic.Models;

namespace NumberSubstitution.Third.BusinessLogic
{
    public interface IDerivationService
    {
        CoreReturnValue GetDerivedMatches(int firstNumber, int secondNumber);
    }
}
