using System;

namespace SOLID._3._Liskov_Substitution.After
{
    public class Client
    {
        void Execute(IDoSomeMathPairNumbers calculator, double value)
        {
            if (calculator.IsValid(value))
            {
                calculator.Execute(value);
            }
        }
    }

    public interface IDoSomeMathPairNumbers
    {
        double Execute(double value);
        bool IsValid(double value);
    }

    class Add : IDoSomeMathPairNumbers
    {
        public double AnotherValue { get; set; }

        public double Execute(double value)
            => AnotherValue + value;

        public bool IsValid(double value)
            => value % 2 == 0;
    }

    class Substract : IDoSomeMathPairNumbers
    {
        public double Execute(double value)
            => Math.PI - value;

        public bool IsValid(double value)
            => value % 2 == 0 && value > 100;
    }
}
