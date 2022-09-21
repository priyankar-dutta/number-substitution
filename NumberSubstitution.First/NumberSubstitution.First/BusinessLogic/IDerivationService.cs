using NumberSubstitution.First.BusinessLogic.Models;

namespace NumberSubstitution.First.BusinessLogic
{
    public interface IDerivationService
    {
        CoreReturnValue GetDerivedMatches(int firstNumber, int secondNumber);
    }
}
