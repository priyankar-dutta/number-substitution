using Microsoft.Extensions.Options;
using NumberSubstitution.Second.CoreLogic;
using NumberSubstitution.Second.Settings;

namespace NumberSubstitution.Second.UnitTests.CoreLogic
{
    [TestFixture]
    public class NumberSubstitutionServiceTests
    {
        private IOptions<AppSettings> _settings;

        private NumberSubstitutionService _service;

        [SetUp]
        public void Setup()
        {
            var numberReplacementDictionary = new Dictionary<string, string>()
            {
                { "2", "hello" },
                { "3", "world" }
            };

            var numberReplacementOverrideDictionary = new Dictionary<string, string>()
            {
                { "3", "universe" },
                { "6", "galaxy" }
            };

            var appSettings = new AppSettings
            {
                NumberReplacementDictionaryData = numberReplacementDictionary,
                NumberReplacementOverrideDictionaryData = numberReplacementOverrideDictionary
            };
            _settings = Options.Create(appSettings);

            _service = new NumberSubstitutionService(_settings);
        }

        [TestCase(5)]
        [TestCase(7)]
        [TestCase(19)]
        public void GetMatches_Should_ReturnEmptyListIfNoMatchFromEitherDictionary(int number)
        {
            var result = _service.GetMatches(number);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Count.EqualTo(0));
        }

        [TestCase(3, ExpectedResult = "universe")]
        [TestCase(13, ExpectedResult = "universe")]
        [TestCase(31, ExpectedResult = "universe")]
        [TestCase(16, ExpectedResult = "galaxy")]
        [TestCase(26, ExpectedResult = "galaxy")]
        [TestCase(2, ExpectedResult = "hello")]
        [TestCase(8, ExpectedResult = "hello")]
        public string GetMatches_Should_ReturnValueFromDictionaryIfSingleMatchExists(int number)
        {
            var result = _service.GetMatches(number);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Count.EqualTo(1));

            return result[0];
        }

        [Test]
        public void GetMatches_Should_ReturnMultipleValuesFromOverrideDictionaryIfMultipleMatchExists()
        {
            var result = _service.GetMatches(36);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Count.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(result[0], Is.EqualTo("universe"));
                Assert.That(result[1], Is.EqualTo("galaxy"));
            });
        }

        [Test]
        public void GetMatches_Should_ReturnMultipleValuesFromDictionaryIfMultipleMatchExists()
        {
            var result = _service.GetMatches(12);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Count.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(result[0], Is.EqualTo("hello"));
                Assert.That(result[1], Is.EqualTo("world"));
            });
        }
    }
}
