using System;

// Creativity:
// This program exceeds the core requirements by allowing the user
// to record their mood with each journal entry.
// The mood is saved, loaded, and displayed with every journal entry.

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Write a new Entry");
            Console.WriteLine("2. Display the Journal");
            Console.WriteLine("3. Load Journal from File");
            Console.WriteLine("4. Save Journal to File");
            Console.WriteLine("5. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                string prompt = promptGenerator.GetRandomPrompt();

                Console.WriteLine();
                Console.WriteLine("How are you feeling today?");
                Console.WriteLine("1. Happy");
                Console.WriteLine("2. Okay");
                Console.WriteLine("3. Sad");
                Console.Write("> ");

                string mood = Console.ReadLine();

                Console.WriteLine();
                Console.WriteLine(prompt);
                Console.Write("> ");

                Entry entry = new Entry();

                entry._date = DateTime.Now.ToShortDateString();
                entry._mood = mood;
                entry._promptText = prompt;
                entry._entryText = Console.ReadLine();

                journal.AddEntry(entry);
            }

            else if (choice == 2)
            {
                journal.DisplayAll();
            }

            else if (choice == 3)
            {
                Console.Write("Enter filename: ");
                string file = Console.ReadLine();

                journal.LoadFromFile(file);

                Console.WriteLine("Journal loaded successfully.");
            }

            else if (choice == 4)
            {
                Console.Write("Enter filename: ");
                string file = Console.ReadLine();

                journal.SaveToFile(file);

                Console.WriteLine("Journal saved successfully.");
            }

            else if (choice == 5)
            {
                Console.WriteLine("Goodbye!");
            }

            else
            {
                Console.WriteLine("Invalid option.");
            }
        }
    }
}