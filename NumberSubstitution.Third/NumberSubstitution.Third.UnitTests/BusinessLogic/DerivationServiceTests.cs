using NumberSubstitution.Third.BusinessLogic;
using NumberSubstitution.Third.CoreLogic;

namespace NumberSubstitution.Third.UnitTests.BusinessLogic
{
    [TestFixture]
    public class DerivationServiceTests
    {
        private INumberSubstitutionService _numberSubstitutionService;

        private DerivationService _service;

        [SetUp]
        public void Setup()
        {
            _numberSubstitutionService = Substitute.For<INumberSubstitutionService>();

            _numberSubstitutionService.GetMatches(1).Returns(new List<string>());
            _numberSubstitutionService.GetMatches(2).Returns(new List<string> { "Match1" });
            _numberSubstitutionService.GetMatches(3).Returns(new List<string> { "Match1", "Match2" });

            _service = new DerivationService(_numberSubstitutionService);
        }

        [Test]
        public void GetDerivedMatches_Should_ReturnCorrectOutputPrintString()
        {
            var result = _service.GetDerivedMatches(1, 3);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.OutputPrintString, Is.EqualTo("1 Match1 Match1Match2"));
        }

        [Test]
        public void GetDerivedMatches_Should_ReturnCorrectOutputPrintSummaryString()
        {
            var result = _service.GetDerivedMatches(1, 3);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.OutputPrintSummaryString, Is.EqualTo("integer: 1 Match1: 1 Match1Match2: 1"));
        }
    }
}
