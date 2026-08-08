using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
        )
    {
    }

    public void Run()
    {
        Start();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        bool breathingIn = true;

        while (DateTime.Now < endTime)
        {
            if (breathingIn)
            {
                Console.Write("Breathe in...");
                ShowCountdown(4);
            }
            else
            {
                Console.Write("Breathe out...");
                ShowCountdown(6);
            }

            Console.WriteLine();

            breathingIn = !breathingIn;
        }

        End();
    }
}