using Microsoft.Extensions.DependencyInjection;
using NumberSubstitution.Third.BusinessLogic;

namespace NumberSubstitution.Third
{
    static class Program
    {
        static void Main()
        {
            IServiceCollection services = new ServiceCollection();
            Startup.ConfigureServices(services);

            IServiceProvider provider = services.BuildServiceProvider();

            Console.WriteLine("Please enter the first number");
            int firstNumber = GetIntegerValueFromConsole();

            Console.WriteLine("Please enter the second number");
            var secondNumber = GetIntegerValueFromConsole();

            while (firstNumber > secondNumber)
            {
                Console.WriteLine("Second number must be greater than the first number - Please enter the second number again");
                secondNumber = GetIntegerValueFromConsole();
            }

            var _derivationService = provider.GetRequiredService<IDerivationService>();

            var outputData = _derivationService.GetDerivedMatches(firstNumber, secondNumber);

            Console.WriteLine("Output printed below:");
            Console.WriteLine(outputData.OutputPrintString);
            Console.WriteLine(outputData.OutputPrintSummaryString);
            Console.ReadLine();
        }

        /// <summary>
        /// Fetch a positive integer from console
        /// </summary>
        /// <returns>Value entered by user</returns>
        private static int GetIntegerValueFromConsole()
        {
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out int number) && number > 0)
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Invalid value entered (must be a positive integer number) - Please try again");
                }
            }
        }
    }
}