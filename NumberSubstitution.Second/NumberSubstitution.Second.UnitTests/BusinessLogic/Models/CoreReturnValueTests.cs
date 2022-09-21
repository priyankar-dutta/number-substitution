using NumberSubstitution.Second.BusinessLogic.Models;

namespace NumberSubstitution.Second.UnitTests.BusinessLogic.Models
{
    [TestFixture]
    public class CoreReturnValueTests
    {
        [Test]
        public void Ctor_Should_CorrectlyAssignValues()
        {
            var outputPrintString = "SomeRandomOutputString";

            var result = new CoreReturnValue(outputPrintString);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.OutputPrintString, Is.EqualTo(outputPrintString));
        }
    }
}
