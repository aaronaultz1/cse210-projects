using System;

class Program
{
    public class Fraction
    {
        // Attributes
        private int _top;
        private int _bottom;

        // Constructors
        public Fraction() // No parameters
        {
            _top = 1;
            _bottom = 1;
        }
        public Fraction(int top) // Top parameter
        {
            _top = top;
            _bottom = 1;
        }
        public Fraction(int top, int bottom) // Top and bottom parameters
        {
            _top = top;
            _bottom = bottom;
        }

    }
    static void Main()
    {
        Fraction f1 = new Fraction();
        Fraction f2 = new Fraction(5);
        Fraction f3 = new Fraction(5, 4);
        Console.WriteLine($"{f1}\n{f2}\n{f3}");
    }
}