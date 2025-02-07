namespace DelegateNewProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Icalculator calculator = new Calculator();

            Func<double, double, double> sum = (num1, num2) => num1 + num2;
            Func<double, double, double> minus = (num1, num2) => num1 - num2;
            Func<double, double, double> baz = (num1, num2) => num1 * num2;
            Func<double, double, double> div = (num1, num2) => num1 / num2;
        }
    }
    interface Icalculator
    {
      double Calculate(double num1, double num2,Func<double,double,double> operation);
    }

    class Calculator : Icalculator
    {
        public double Calculate(double num1, double num2, Func<double, double, double> operation)
        {
            return operation(num1, num2);
        }
    }
}
