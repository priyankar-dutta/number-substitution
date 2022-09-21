using Microsoft.Extensions.Options;
using NumberSubstitution.First.Settings;

namespace NumberSubstitution.First.CoreLogic
{
    public class NumberSubstitutionService : INumberSubstitutionService
    {
        private readonly Dictionary<string, string> _masterData;

        public NumberSubstitutionService(IOptions<AppSettings> settings)
        {
            _masterData = settings.Value.NumberReplacementDictionaryData;
        }

        /// <summary>
        /// If number has factors in the data dictionary, then return the list of corresponding matched texts
        /// </summary>
        public List<string> GetMatches(int number)
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
    }
}
