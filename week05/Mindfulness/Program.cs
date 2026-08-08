using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        /*
         * Creativity and Exceeding Requirements:
         *
         * In addition to the core requirements, this program keeps track
         * of how many times each mindfulness activity has been completed
         * during the current session. The statistics are displayed when
         * the user chooses to quit the program.
         *
         * This provides the user with a simple way to see how often they
         * practiced each type of mindfulness activity.
         */

        Dictionary<string, int> activityCounts =
            new Dictionary<string, int>();

        activityCounts["Breathing"] = 0;
        activityCounts["Reflection"] = 0;
        activityCounts["Listing"] = 0;

        bool running = true;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("Mindfulness Program");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflection activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.WriteLine();
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity =
                        new BreathingActivity();

                    breathingActivity.Run();

                    activityCounts["Breathing"]++;
                    break;

                case "2":
                    ReflectingActivity reflectingActivity =
                        new ReflectingActivity();

                    reflectingActivity.Run();

                    activityCounts["Reflection"]++;
                    break;

                case "3":
                    ListingActivity listingActivity =
                        new ListingActivity();

                    listingActivity.Run();

                    activityCounts["Listing"]++;
                    break;

                case "4":
                    Console.Clear();

                    Console.WriteLine("Thank you for using the Mindfulness Program!");
                    Console.WriteLine();
                    Console.WriteLine("Session Summary:");
                    Console.WriteLine(
                        $"Breathing activities completed: {activityCounts["Breathing"]}"
                    );
                    Console.WriteLine(
                        $"Reflection activities completed: {activityCounts["Reflection"]}"
                    );
                    Console.WriteLine(
                        $"Listing activities completed: {activityCounts["Listing"]}"
                    );

                    Console.WriteLine();
                    Console.WriteLine("Have a peaceful day!");

                    running = false;
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Please enter a valid option.");

                    System.Threading.Thread.Sleep(1500);
                    break;
            }
        }
    }
}