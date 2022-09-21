using Microsoft.Extensions.Options;
using NumberSubstitution.First.CoreLogic;
using NumberSubstitution.First.Settings;

namespace NumberSubstitution.First.UnitTests.CoreLogic
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

            var appSettings = new AppSettings
            {
                NumberReplacementDictionaryData = numberReplacementDictionary
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

        [TestCase(3, ExpectedResult = "world")]
        [TestCase(26, ExpectedResult = "hello")]
        [TestCase(2, ExpectedResult = "hello")]
        [TestCase(9, ExpectedResult = "world")]
        public string GetMatches_Should_ReturnValueFromDictionaryIfSingleMatchExists(int number)
        {
            var result = _service.GetMatches(number);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Count.EqualTo(1));

            return result[0];
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
