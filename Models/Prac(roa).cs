using System;
using System.Linq;

public class Class1
{
    public static void PrintThirdLargestEven(int[] numbers)
    {
        int[] evenNumbers = numbers
            .Where(n => n % 2 == 0)
            .Distinct()
            .OrderByDescending(n => n)
            .ToArray();

        if (evenNumbers.Length >= 3)
        {
            Console.WriteLine($"The third largest even number is: {evenNumbers[2]}");
        }
        else
        {
            Console.WriteLine("There are fewer than three distinct even numbers.");
        }
    }
}