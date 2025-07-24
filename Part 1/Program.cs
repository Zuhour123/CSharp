using System;

class Program
{
    static void Main()
    {
        // Display a welcome message to the user
        Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");

        // Prompt the user to enter the package weight
        Console.WriteLine("Please enter the package weight:");
        // Read and convert the weight input to a decimal number
        decimal weight = Convert.ToDecimal(Console.ReadLine());

        // Check if the package weight exceeds 50
        if (weight > 50)
        {
            // Display an error message and exit the program
            Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
            return; // Ends the program early
        }

        // Prompt the user to enter the package width
        Console.WriteLine("Please enter the package width:");
        decimal width = Convert.ToDecimal(Console.ReadLine());

        // Prompt the user to enter the package height
        Console.WriteLine("Please enter the package height:");
        decimal height = Convert.ToDecimal(Console.ReadLine());

        // Prompt the user to enter the package length
        Console.WriteLine("Please enter the package length:");
        decimal length = Convert.ToDecimal(Console.ReadLine());

        // Calculate the total size of the package by summing dimensions
        decimal dimensionTotal = width + height + length;

        // Check if the combined dimensions exceed 50
        if (dimensionTotal > 50)
        {
            // Display an error message and exit the program
            Console.WriteLine("Package too big to be shipped via Package Express.");
            return; // Ends the program early
        }

        // Calculate the shipping quote using the formula:
        // (Width * Height * Length * Weight) / 100
        decimal quote = (width * height * length * weight) / 100;

        // Display the final quote to the user in currency format
        Console.WriteLine("Your estimated total for shipping this package is: $" + quote.ToString("0.00"));

        // Thank the user
        Console.WriteLine("Thank you!");
    }
}
