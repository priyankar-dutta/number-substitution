using NumberSubstitution.Third.BusinessLogic.Models;

namespace NumberSubstitution.Third.UnitTests.BusinessLogic.Models
{
    [TestFixture]
    public class CoreReturnValueTests
    {
        [Test]
        public void Ctor_Should_CorrectlyAssignValues()
        {
            var outputPrintString = "SomeRandomOutputString";
            var outputPrintSummaryString = "SomeRandomPrintSummaryString";

            var result = new CoreReturnValue(outputPrintString, outputPrintSummaryString);
            
            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.OutputPrintString, Is.EqualTo(outputPrintString));
                Assert.That(result.OutputPrintSummaryString, Is.EqualTo(outputPrintSummaryString));
            });
        }
    }
}
