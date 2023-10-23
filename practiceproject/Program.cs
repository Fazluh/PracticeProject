using practiceproject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static List<Student> students = new List<Student>();

    static void Main(string[] args)
    {
        string filePath = @"D:\filehandling\Person2.txt"; // Update this with the actual file path.

        LoadStudentData(filePath);

        while (true)
        {
            Console.WriteLine("Options:");
            Console.WriteLine("1. Display all students (sorted by name)");
            Console.WriteLine("2. Search for a student by name");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        DisplayStudents();
                        break;
                    case 2:
                        Console.Write("Enter the student's name to search: ");
                        string searchName = Console.ReadLine();
                        SearchStudent(searchName);
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid option.");
            }
        }
    }


    static void LoadStudentData(string filePath)
    {
        try
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2)
                {
                    string name = parts[0].Trim();
                    string className = parts[1].Trim();
                    students.Add(new Student(name, className));
                }
            }

            students = students.OrderBy(s => s.Name).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error loading data: {e.Message}");
        }
    }

    static void DisplayStudents()
    {
        Console.WriteLine("Students (sorted by name):");
        foreach (var student in students)
        {
            Console.WriteLine($"{student.Name}, {student.Class}");
        }
    }

    static void SearchStudent(string searchName)
    {
        var results = students.Where(s => s.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase)).ToList();

        if (results.Count > 0)
        {
            Console.WriteLine("Search Results:");
            foreach (var student in results)
            {
                Console.WriteLine($"{student.Name}, {student.Class}");
            }
        }
        else
        {
            Console.WriteLine("No student found with the given name.");
        }
    }
}


