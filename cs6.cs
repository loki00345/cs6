using System;
using System.Collections.Generic;

//1
class EmployeeManager
{
    private Dictionary<string, string> employeeData = new Dictionary<string, string>();

    public void AddEmployee(string login, string password)
    {
        if (!employeeData.ContainsKey(login))
        {
            employeeData[login] = password;
            Console.WriteLine($"Added employee: {login}");
        }
        else
        {
            Console.WriteLine("Employee already exists.");
        }
    }

    public void RemoveEmployee(string login)
    {
        if (employeeData.Remove(login))
        {
            Console.WriteLine($"Removed employee: {login}");
        }
        else
        {
            Console.WriteLine("Employee not found.");
        }
    }

    public void UpdateEmployee(string login, string newPassword)
    {
        if (employeeData.ContainsKey(login))
        {
            employeeData[login] = newPassword;
            Console.WriteLine($"Updated password for employee: {login}");
        }
        else
        {
            Console.WriteLine("Employee not found.");
        }
    }

    public void GetPassword(string login)
    {
        if (employeeData.TryGetValue(login, out string password))
        {
            Console.WriteLine($"Password for {login}: {password}");
        }
        else
        {
            Console.WriteLine("Employee not found.");
        }
    }
}

//2
class FrenchDictionary
{
    private Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

    public void AddWord(string englishWord, List<string> frenchTranslations)
    {
        dictionary[englishWord] = frenchTranslations;
        Console.WriteLine($"Added/Updated word: {englishWord}");
    }

    public void RemoveWord(string englishWord)
    {
        if (dictionary.Remove(englishWord))
        {
            Console.WriteLine($"Removed word: {englishWord}");
        }
        else
        {
            Console.WriteLine("Word not found.");
        }
    }

    public void RemoveTranslation(string englishWord, string frenchTranslation)
    {
        if (dictionary.TryGetValue(englishWord, out List<string> translations))
        {
            if (translations.Remove(frenchTranslation))
            {
                Console.WriteLine($"Removed translation: {frenchTranslation}");
            }
            else
            {
                Console.WriteLine("Translation not found.");
            }
        }
        else
        {
            Console.WriteLine("Word not found.");
        }
    }

    public void SearchWord(string englishWord)
    {
        if (dictionary.TryGetValue(englishWord, out List<string> translations))
        {
            Console.WriteLine($"Translations for {englishWord}: {string.Join(", ", translations)}");
        }
        else
        {
            Console.WriteLine("Word not found.");
        }
    }
}

//3
class CafeQueue
{
    private Queue<string> queue = new Queue<string>();
    private List<string> reserved = new List<string>();

    public void AddToQueue(string customerName)
    {
        queue.Enqueue(customerName);
        Console.WriteLine($"Added to queue: {customerName}");
    }

    public void AddReservation(string customerName)
    {
        reserved.Add(customerName);
        Console.WriteLine($"Reserved table for: {customerName}");
    }

    public void ServeNextCustomer()
    {
        if (reserved.Count > 0)
        {
            string customer = reserved[0];
            reserved.RemoveAt(0);
            Console.WriteLine($"Serving reserved customer: {customer}");
        }
        else if (queue.Count > 0)
        {
            string customer = queue.Dequeue();
            Console.WriteLine($"Serving customer: {customer}");
        }
        else
        {
            Console.WriteLine("No customers to serve.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Choose task (1-3):");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                var manager = new EmployeeManager();
                manager.AddEmployee("john.doe", "password123");
                manager.GetPassword("john.doe");
                manager.UpdateEmployee("john.doe", "newpassword");
                manager.RemoveEmployee("john.doe");
                break;

            case 2:
                var dict = new FrenchDictionary();
                dict.AddWord("apple", new List<string> { "pomme" });
                dict.SearchWord("apple");
                dict.RemoveTranslation("apple", "pomme");
                dict.RemoveWord("apple");
                break;

            case 3:
                var cafe = new CafeQueue();
                cafe.AddToQueue("Alice");
                cafe.AddReservation("Bob");
                cafe.ServeNextCustomer();
                cafe.ServeNextCustomer();
                cafe.ServeNextCustomer();
                break;

            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }
}