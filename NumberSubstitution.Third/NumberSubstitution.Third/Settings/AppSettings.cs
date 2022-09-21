namespace NumberSubstitution.Third.Settings
{
    public class AppSettings
    {
        public Dictionary<string, string> NumberReplacementDictionaryData { get; set; } = new Dictionary<string, string>();

        public Dictionary<string, string> NumberReplacementOverrideDictionaryData { get; set; } = new Dictionary<string, string>();
    }
}
