using System; // Import the System namespace for basic functionality like Console

// Define an interface named IQuittable
public interface IQuittable
{
    // Declare a method signature for Quit with no return type
    void Quit();
}

// Define the Employee class, implementing the IQuittable interface
public class Employee : IQuittable
{
    // Property to store the Employee's unique identifier
    public int Id { get; set; }

    // Property to store the Employee's first name
    public string FirstName { get; set; }

    // Property to store the Employee's last name
    public string LastName { get; set; }

    // Implementation of the Quit() method from the IQuittable interface
    public void Quit()
    {
        // Display a message indicating the employee has quit
        Console.WriteLine($"{FirstName} {LastName} (ID: {Id}) has quit the job.");
    }

    // Overload the == operator to compare two Employee objects by Id
    public static bool operator ==(Employee emp1, Employee emp2)
    {
        // If both references are the same, return true
        if (ReferenceEquals(emp1, emp2))
            return true;

        // If either object is null, return false
        if ((object)emp1 == null || (object)emp2 == null)
            return false;

        // Compare the Ids
        return emp1.Id == emp2.Id;
    }

    // Overload the != operator (required when overloading ==)
    public static bool operator !=(Employee emp1, Employee emp2)
    {
        return !(emp1 == emp2); // Return the inverse of ==
    }

    // Override Equals to ensure compatibility with == operator
    public override bool Equals(object obj)
    {
        var other = obj as Employee;
        if (other == null) return false;
        return this.Id == other.Id;
    }

    // Override GetHashCode to match Equals
    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }
}

// Main program class where execution starts
class Program
{
    // Main method - entry point of the application
    static void Main(string[] args)
    {
        // Create an instance of Employee and assign property values
        Employee emp = new Employee
        {
            Id = 105,
            FirstName = "Zuhour",
            LastName = "Eid"
        };

        // Use polymorphism: declare an object of interface type IQuittable
        IQuittable quittableEmployee = emp;

        // Call the Quit() method using the interface reference
        quittableEmployee.Quit();

        // Wait for user input to keep console window open (optional)
        Console.ReadLine();
    }
}
