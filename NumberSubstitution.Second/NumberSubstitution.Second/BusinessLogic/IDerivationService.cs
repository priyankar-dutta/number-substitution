using NumberSubstitution.Second.BusinessLogic.Models;

namespace NumberSubstitution.Second.BusinessLogic
{
    public interface IDerivationService
    {
        CoreReturnValue GetDerivedMatches(int firstNumber, int secondNumber);
    }
}
