using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment assignment1 = new MathAssignment("Jeff", "Math", "Section 7.3", "Problems 8-24");
        Console.WriteLine(assignment1.GetSummary());
        Console.WriteLine(assignment1.GetHomeWorkList());

        WritingAssignment assignment2 = new WritingAssignment("Gerald", "Writing", "The Great Civil War");
        Console.WriteLine(assignment2.GetSummary());
        Console.WriteLine(assignment2.GetWritingInformation());
    }
}