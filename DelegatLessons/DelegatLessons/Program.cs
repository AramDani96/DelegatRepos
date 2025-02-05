using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace DelegatLessons
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyDelegate myDelegate = new MyDelegate(PrintNumber);
            myDelegate+= PrintSquare;
            myDelegate(5);


            SumDelegate sumDelegate = Sum;
            Console.WriteLine(sumDelegate(5, 6));

            SumDelegate sumDelegate1 = delegate (int num, int num1) { return num + num1; };

            Console.WriteLine(sumDelegate1(15,44));

            SumDelegate del = (num1, num2) => num1 + num2;

            Console.WriteLine(del(10, 10));

            Action<int> prinNumber = number => Console.WriteLine(+number);
            prinNumber(5);

            Func<int,int,int> sum = (num1,num2)=> num1 + num2;

            Console.WriteLine(sum(3, 4));

            Predicate<int> even = number => number%2 == 0;

            Console.WriteLine(even(6));

            int plusresult = PerformOperation(2,3,(num1,num2)=> num1+num2);
            Console.WriteLine(plusresult);

            int minusresult = PerformOperation(5, 3, (num1, num2) => num1 - num2);
            Console.WriteLine(minusresult);

            int num = GetOperation()(2, 3);
            Console.WriteLine(num);
        }
        public delegate void MyDelegate(int number);

        public delegate int SumDelegate(int Number1, int Number2);
        static void PrintNumber(int number)
        { 
          Console.WriteLine(number);
        }
        static void PrintSquare(int number)
        { 
        Console.WriteLine("Square = " + number * number);
        }
        static int Sum(int Number1, int Number2)
        {
            return Number1 + Number2;
        }

        static int PerformOperation(int num1, int num2, Func<int, int, int> operation)
        {
            return operation(num1,num2);
        }

        static Func<int, int, int>  GetOperation()
        {
            return (num1,num2) => num1 * num2;
        }
    }
}
