using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage?");
        string answer= Console.ReadLine();
        int percent= int.Parse(answer);

        string letter= "";
        
        if(percent >= 90)
        {
            letter= "A";
        }
        else if(percent >= 80)
        {
            letter= "B";
        }
        else if (percent >= 70)
        {
            letter= "C";
        }
        else if(percent >= 60)
        {
            letter= "D";
        }
        else 
        {
            letter= "F";
        }
        string sign ="";
        int last_Digit = percent % 10;
        
        if (last_Digit >=7)
        {
            sign= "+";
        }
        else if (last_Digit <3 && letter!="A")
        {
            sign= "-";
        }
        else
        {
            sign="";
        }
       if(letter =="A" && last_Digit >= 7)
        {
            sign ="";
        }
        else if (letter =="F")
        {
            sign="" ;
       }

        Console.WriteLine($"Your grade is: {letter}{sign}");
       if (percent >=70)
        {
            Console.WriteLine("You passed!");
        }
       else 
        {
            Console.WriteLine("Better luck next time!");
        }
    }
}