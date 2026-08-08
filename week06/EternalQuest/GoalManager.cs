using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void CreateGoal()
    {
        Console.WriteLine("What type of goal would you like to create?");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Select a choice: ");

        string choice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (choice == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (choice == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (choice == "3")
        {
            Console.Write("How many times does this goal need to be completed? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for completing it? ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(
                new ChecklistGoal(
                    name,
                    description,
                    points,
                    target,
                    bonus));
        }
    }

    public void ListGoals()
    {
        Console.WriteLine("The goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void RecordEvent()
    {
        ListGoals();

        Console.Write("Which goal did you accomplish? ");

        int choice = int.Parse(Console.ReadLine());

        if (choice < 1 || choice > _goals.Count)
        {
            Console.WriteLine("Invalid goal.");
            return;
        }

        Goal goal = _goals[choice - 1];

        if (goal is SimpleGoal simpleGoal)
        {
            if (!simpleGoal.IsComplete())
            {
                simpleGoal.RecordEvent();
                _score += simpleGoal.GetPoints();

                Console.WriteLine(
                    $"Congratulations! You earned {simpleGoal.GetPoints()} points.");
            }
            else
            {
                Console.WriteLine("That goal is already complete.");
            }
        }
        else if (goal is EternalGoal eternalGoal)
        {
            eternalGoal.RecordEvent();
            _score += eternalGoal.GetPoints();

            Console.WriteLine(
                $"You earned {eternalGoal.GetPoints()} points!");
        }
        else if (goal is ChecklistGoal checklistGoal)
        {
            int previousAmount = checklistGoal.GetAmountCompleted();

            checklistGoal.RecordEvent();

            if (checklistGoal.GetAmountCompleted() > previousAmount)
            {
                _score += checklistGoal.GetPoints();

                Console.WriteLine(
                    $"You earned {checklistGoal.GetPoints()} points!");

                if (checklistGoal.IsComplete()
                    && previousAmount < checklistGoal.GetAmountCompleted())
                {
                    _score += checklistGoal.GetBonus();

                    Console.WriteLine(
                        $"Congratulations! You earned a bonus of {checklistGoal.GetBonus()} points!");
                }
            }
        }

        Console.WriteLine($"Your current score is: {_score}");
    }

   public void DisplayScore()
{
    int level = (_score / 500) + 1;

    Console.WriteLine($"Your current score is: {_score}");
    Console.WriteLine($"Your current level is: {level}");

    if (_score >= 500)
    {
        Console.WriteLine("Keep going! You are leveling up your Eternal Quest!");
    }
}

    public void SaveGoals()
    {
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("|");

            if (parts[0] == "SimpleGoal")
            {
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);
                bool isComplete = bool.Parse(parts[4]);

                SimpleGoal goal =
                    new SimpleGoal(name, description, points);

                if (isComplete)
                {
                    goal.RecordEvent();
                }

                _goals.Add(goal);
            }
            else if (parts[0] == "EternalGoal")
            {
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                _goals.Add(
                    new EternalGoal(
                        name,
                        description,
                        points));
            }
            else if (parts[0] == "ChecklistGoal")
            {
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);
                int target = int.Parse(parts[4]);
                int bonus = int.Parse(parts[5]);
                int amountCompleted = int.Parse(parts[6]);

                ChecklistGoal goal =
                    new ChecklistGoal(
                        name,
                        description,
                        points,
                        target,
                        bonus);

                for (int j = 0; j < amountCompleted; j++)
                {
                    goal.RecordEvent();
                }

                _goals.Add(goal);
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }
}