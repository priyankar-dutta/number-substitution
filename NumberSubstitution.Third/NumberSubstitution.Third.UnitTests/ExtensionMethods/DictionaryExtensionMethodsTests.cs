using NumberSubstitution.Third.ExtensionMethods;

namespace NumberSubstitution.Third.UnitTests.ExtensionMethods
{
    public class DictionaryExtensionMethodsTests
    {
        private readonly Dictionary<string, int> _dictionary = new()
        {
            { "someKey", 2 }
        };

        [Test]
        public void AddDictionaryValueCountByOne_Should_AddKeyValuePairIfItDoesNotExist()
        {
            var key = "someOtherKey";
            _dictionary.AddDictionaryValueCountByOne(key);

            Assert.That(_dictionary[key], Is.EqualTo(1));
        }

        [Test]
        public void AddDictionaryValueCountByOne_Should_IncreaseCountOfValueByOneIfItExists()
        {
            var key = "someKey";
            _dictionary.AddDictionaryValueCountByOne(key);

            Assert.That(_dictionary[key], Is.EqualTo(3));
        }
    }
}
