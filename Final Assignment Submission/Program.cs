using ConsoleApp3;
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Creating database and adding a student...");

        // Create a new instance of the database context
        using (var context = new StudentContext())
        {
            // Ensure the database is created
            context.Database.EnsureCreated();

            // Create a new student object
            var student = new Student
            {
                FirstName = "Zuhour",
                LastName = "Eid",
                DateOfBirth = new DateTime(2025, 1, 1)
            };

            // Add the student to the Students DbSet
            context.Students.Add(student);

            // Save changes to the database
            context.SaveChanges();

            Console.WriteLine("Student added successfully!");

            // Retrieve and display the student to verify
            var savedStudent = context.Students.FirstOrDefault(s => s.FirstName == "Feras");
            if (savedStudent != null)
            {
                Console.WriteLine($" Student: {savedStudent.FirstName} {savedStudent.LastName}");
            }
        }

    
    }
}