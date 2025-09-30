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

        public string GetFractionString()
        {
            return _top + "/" + _bottom;
        }
        public double GetDecimalValue()
        {
            return (double)_top / _bottom;
        }
    }
    static void Main()
    {
        Fraction f1 = new Fraction(1);
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());

        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());

        
    }
}