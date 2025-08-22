using System; // Import the System namespace to use Console and other base classes

namespace MathOperationApp // Declare the namespace for the application
{
    // Create a class named 'MathClass'
    class MathClass
    {
        // Define a void method that takes two integers as parameters
        public void PerformOperation(int number1, int number2)
        {
            // Perform a math operation on the first integer (e.g., multiply by 2)
            int result = number1 * 2;

            // Display the result of the math operation
            Console.WriteLine("The result of the math operation on the first number is: " + result);

            // Display the second integer
            Console.WriteLine("The second number is: " + number2);
        }
    }

    // The Program class contains the Main() method - the entry point of the app
    class Program
    {
        // The Main method
        static void Main(string[] args)
        {
            // Instantiate the MathClass object
            MathClass mathObj = new MathClass();

            // Call the PerformOperation method using regular positional parameters
            mathObj.PerformOperation(4, 16);

            // Call the PerformOperation method using named parameters
            mathObj.PerformOperation(number1: 7, number2: 3);

        }
    }
}
