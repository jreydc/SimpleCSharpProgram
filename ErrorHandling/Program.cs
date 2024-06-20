

namespace ErrorHandling
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Error Handling Project!");

            Console.WriteLine("Enter a number: ");
            string? input = Console.ReadLine();

            try
            {
                int number = ParseStringToInt(input);
                Console.WriteLine(
                    "String successfully pased, the result is " + number
                    );
            }catch (Exception ex)
            {
                Console.WriteLine("An exception was thrown."+ ex.Message);
            }finally
            {
                Console.WriteLine("Finally block is being executed.");
            }

            Exit();
        }

        private static void Exit()
        {
            Console.WriteLine("Please Press Any Key to Close!");
            Console.ReadKey();
        }

        private static int ParseStringToInt(string? input) 
        {
            return int.Parse(input);

        } 
    }
}
