using System;

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