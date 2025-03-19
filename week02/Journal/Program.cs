using System;

Journal journal = new Journal();
while (true)
{
    Console.WriteLine("\nJournal Menu:");
    Console.WriteLine("1. Write a new entry");
    Console.WriteLine("2. Display the journal");
    Console.WriteLine("3. Save the journal to a file");
    Console.WriteLine("4. Load the journal from a file");
    Console.WriteLine("5. Exit");
    Console.Write("Choose an option: ");
    string choice = Console.ReadLine();
    Console.WriteLine();

    string file = null;
    switch (choice)
    {
        case "1":
            journal.AddEntry();
            break;
        case "2":
            journal.DisplayAll();
            break;
        case "3":
            journal.SaveToFile(file);
            break;
        case "4":
            journal.LoadFromFile(file);
            break;
        case "5":
            Console.WriteLine("Goodbye!");
            return;
        default:
            Console.WriteLine("Invalid choice, try again.\n");
            break;
    }
}
