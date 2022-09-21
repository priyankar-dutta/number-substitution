namespace NumberSubstitution.First.BusinessLogic.Models
{
    public class CoreReturnValue
    {
        public CoreReturnValue(string outputPrintString)
        {
            OutputPrintString = outputPrintString;
        }

        public string OutputPrintString { get; private set; }
    }
}
