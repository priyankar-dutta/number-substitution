using NumberSubstitution.Third.BusinessLogic.Models;
using NumberSubstitution.Third.CoreLogic;
using NumberSubstitution.Third.ExtensionMethods;
using System.Text;

namespace NumberSubstitution.Third.BusinessLogic
{
    public class DerivationService : IDerivationService
    {
        private readonly INumberSubstitutionService _numberSubstitutionService;
        private const char SpaceSeparator = ' ';
        private const char ColonSeparator = ':';
        private const string IntegerKeyWordToPrint = "integer";

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
            var summaryDictionary = new Dictionary<string, int>();

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

                    summaryDictionary.AddDictionaryValueCountByOne(finalMatchForNumber.ToString());
                }
                else
                {
                    summaryDictionary.AddDictionaryValueCountByOne(IntegerKeyWordToPrint);
                    finalMatchForNumber.Append(i);
                }

                mainOutput.Append(finalMatchForNumber);
                mainOutput.Append(SpaceSeparator);
            }

            var summaryStringBuilder = new StringBuilder();
            foreach (var key in summaryDictionary.Keys)
            {
                summaryStringBuilder.Append(key);
                summaryStringBuilder.Append(ColonSeparator);
                summaryStringBuilder.Append(SpaceSeparator);
                summaryStringBuilder.Append(summaryDictionary[key]);
                summaryStringBuilder.Append(SpaceSeparator);
            }

            return new CoreReturnValue(mainOutput.ToString().Trim(), summaryStringBuilder.ToString().Trim());
        }
    }
}
