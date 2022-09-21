using NumberSubstitution.Second.BusinessLogic.Models;
using NumberSubstitution.Second.CoreLogic;
using System.Text;

namespace NumberSubstitution.Second.BusinessLogic
{
    public class DerivationService : IDerivationService
    {
        private readonly INumberSubstitutionService _numberSubstitutionService;
        private const char SpaceSeparator = ' ';

        public DerivationService(INumberSubstitutionService numberSubstitutionService)
        {
            _numberSubstitutionService = numberSubstitutionService;
        }

        /// <summary>
        /// Iterates over the supplied numbers and generates the pattern to return to user
        /// </summary>
        public CoreReturnValue GetDerivedMatches(int firstNumber, int secondNumber)
        {
            var mainOutput = new StringBuilder();

            for (int i = firstNumber; i <= secondNumber; i++)
            {
                var matches = _numberSubstitutionService.GetMatches(i);
                var finalMatchForNumber = new StringBuilder();

                if (matches != null && matches.Count > 0)
                {
                    foreach (var match in matches)
                    {
                        finalMatchForNumber.Append(match);
                    }
                }
                else
                {
                    finalMatchForNumber.Append(i);
                }

                mainOutput.Append(finalMatchForNumber);
                mainOutput.Append(SpaceSeparator);
            }

            return new CoreReturnValue(mainOutput.ToString().Trim());
        }
    }
}
