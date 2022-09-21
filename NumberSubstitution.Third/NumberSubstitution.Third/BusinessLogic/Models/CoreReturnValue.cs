namespace NumberSubstitution.Third.BusinessLogic.Models
{
    public class CoreReturnValue
    {
        public CoreReturnValue(string outputPrintString, string outputPrintSummaryString)
        {
            OutputPrintString = outputPrintString;
            OutputPrintSummaryString = outputPrintSummaryString;
        }

        public string OutputPrintString { get; private set; }

        public string OutputPrintSummaryString { get; private set; }
    }
}
