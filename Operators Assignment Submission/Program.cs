using System; // Import System namespace to use basic functionalities like Console

// Define the Employee class
public class Employee
{
    // Property to store the Employee's unique identifier
    public int Id { get; set; }

    // Property to store the Employee's first name
    public string FirstName { get; set; }

    // Property to store the Employee's last name
    public string LastName { get; set; }

    // Overload the == operator to compare two Employee objects based on their Id
    public static bool operator ==(Employee emp1, Employee emp2)
    {
        // If both references point to the same object, return true
        if (ReferenceEquals(emp1, emp2))
            return true;

        // If either is null (but not both), return false
        if ((object)emp1 == null || (object)emp2 == null)
            return false;

        // Compare the Id properties
        return emp1.Id == emp2.Id;
    }

    // Overload the != operator to complement the == operator
    public static bool operator !=(Employee emp1, Employee emp2)
    {
        // Return the opposite of the == operator
        return !(emp1 == emp2);
    }

    // Override Equals() to ensure consistency with the == operator
    public override bool Equals(object obj)
    {
        // Try to cast the object to an Employee
        var other = obj as Employee;

        // If the cast fails, return false
        if (other == null) return false;

        // Return true if Ids match
        return this.Id == other.Id;
    }

    // Override GetHashCode() to match the overridden Equals method
    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }
}

// Program class contains the entry point of the application
class Program
{
    // Main method is where the app starts execution
    static void Main(string[] args)
    {
        // Create the first Employee instance and set its properties
        Employee emp1 = new Employee
        {
            Id = 105,
            FirstName = "Zuhour",
            LastName = "Eid"
        };

        // Create the second Employee instance with the same Id
        Employee emp2 = new Employee
        {
            Id = 101, // Same Id as emp1 to simulate equality
            FirstName = "Ahmed",
            LastName = "Ahmed"
        };

        // Compare the two employees using the overloaded == operator
        if (emp1 == emp2)
        {
            Console.WriteLine("emp1 and emp2 are considered equal based on their Ids.");
        }
        else
        {
            Console.WriteLine("emp1 and emp2 are NOT equal.");
        }

        // Compare using the overloaded != operator
        if (emp1 != emp2)
        {
            Console.WriteLine("emp1 and emp2 are NOT equal (using !=).");
        }
        else
        {
            Console.WriteLine("emp1 and emp2 are equal (using !=).");
        }

        // Keep the console window open until user presses Enter
        Console.ReadLine();
    }
}
