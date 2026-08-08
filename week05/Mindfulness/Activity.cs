using System;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    public void Start()
    {
        Console.Clear();

        Console.WriteLine($"--- {_name} Activity ---");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());

        Console.Clear();

        Console.WriteLine("Get ready...");
        ShowSpinner(3);

        Console.WriteLine();
    }

    public void End()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        Console.WriteLine();

        ShowSpinner(2);

        Console.WriteLine();
        Console.WriteLine(
            $"You have completed the {_name} Activity for {_duration} seconds."
        );

        ShowSpinner(3);

        Console.Clear();
    }

    protected int GetDuration()
    {
        return _duration;
    }

    protected void ShowSpinner(int seconds)
    {
        string[] animation = { "|", "/", "-", "\\" };

        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int index = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(animation[index]);
            Thread.Sleep(250);
            Console.Write("\b \b");

            index++;

            if (index >= animation.Length)
            {
                index = 0;
            }
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    protected void PauseWithSpinner(int seconds)
    {
        ShowSpinner(seconds);
        Console.WriteLine();
    }
}