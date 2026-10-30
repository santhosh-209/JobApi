/// <summary>
/// Checks if a given integer is a prime number.
/// </summary>
/// <param name="number">The number to check.</param>
/// <returns>True if the number is prime; otherwise, false.</returns>
public static bool IsPrime(int number)
{
    // Eliminate numbers less than or equal to 1
    if (number <= 1) return false;

    // 2 is the only even prime number
    if (number == 2) return true;

    // Eliminate all other even numbers
    if (number % 2 == 0) return false;

    // Check odd divisors up to the square root of the number
    int boundary = (int)Math.Floor(Math.Sqrt(number));

    for (int i = 3; i <= boundary; i += 2)
    {
        if (number % i == 0) return false;
    }

    return true;
}
