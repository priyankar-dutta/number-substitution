using Microsoft.Extensions.Options;
using NumberSubstitution.Third.Settings;

namespace NumberSubstitution.Third.CoreLogic
{
    public class NumberSubstitutionService : INumberSubstitutionService
    {
        private readonly Dictionary<string, string> _masterData;
        private readonly Dictionary<string, string> _masterOverrideData;

        public NumberSubstitutionService(IOptions<AppSettings> settings)
        {
            _masterData = settings.Value.NumberReplacementDictionaryData;
            _masterOverrideData = settings.Value.NumberReplacementOverrideDictionaryData;
        }

        private List<string> GetRegularMatches(int number)
        {
            var matches = new List<string>();

            foreach (var key in _masterData.Keys)
            {
                if (number % Convert.ToInt32(key) == 0)
                {
                    matches.Add(_masterData[key]);
                }
            }

            return matches;
        }

        /// <summary>
        /// If the input number contains any digit in the override dictionary then return the matched values from dictionary
        /// </summary>
        private List<string> GetOverrideMatches(int number)
        {
            return (_masterOverrideData.Keys.Where(key => number.ToString().Contains(key)).Select(key => _masterOverrideData[key])).ToList();
        }

        /// <summary>
        /// If number satisfies override condition, then returns the override matches
        /// If number does not satisfy override condition, then returns the regular matches
        /// </summary>
        public List<string> GetMatches(int number)
        {
            var overrideMatches = GetOverrideMatches(number);
            return overrideMatches.Count == 0 ? GetRegularMatches(number) : overrideMatches;
        }
    }
}
