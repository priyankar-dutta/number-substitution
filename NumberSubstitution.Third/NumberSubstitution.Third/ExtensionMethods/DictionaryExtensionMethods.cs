namespace NumberSubstitution.Third.ExtensionMethods
{
    public static class DictionaryExtensionMethods
    {
        /// <summary>
        /// Created because int based dictionaries require keys to be added explicitly
        /// </summary>
        public static void AddDictionaryValueCountByOne(this Dictionary<string, int> dictionary, string key)
        {
            dictionary[key] = dictionary.TryGetValue(key, out int value) ? value + 1 : 1;
        }
    }
}
