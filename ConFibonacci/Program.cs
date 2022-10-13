
namespace ConFibonacci;

public static class Program
{
    /// <summary>
    /// Outputs the fibonacci sequence up to very large numbers.
    /// Stops when number may be too large to store in a 'ulong'
    /// </summary>
    private static void OutputFibonacci()
    {
        ulong x1 = 1;
        ulong x2 = 1;
        Console.WriteLine($"{x1}\n{x2}");

        while (x1 < 10000000000000000000)
        {
            ulong x3 = x1 + x2;
            x2 = x1;
            x1 = x3;
            Console.WriteLine($"{x3}");
        }
    }

    /// <summary>
    /// Recursively calculates the fibonacci at a particular index in the sequence
    /// </summary>
    /// <param name="index">The index to get the value from in the fibonacci number set</param>
    /// <returns>The value associated with that index within the fibonacci number set</returns>
    private static ulong GetFibonacciAtIndex(ushort index)
    {
        if (index < 2)
            return index;
        return GetFibonacciAtIndex((ushort)(index - 1)) + GetFibonacciAtIndex((ushort)(index - 2));
    }
    
    public static void Main()
    {
        // OutputFibonacci(); // Print out a list of fibonacci numbers (caps when numbers start being very large)

        while (true)
        {
            try
            {
                Console.Write("Enter index: ");
                var input = Console.ReadLine();
                if (input is null) break;
                var index = Convert.ToUInt16(input);
                if (index > 96)
                    throw new Exception();
                Console.WriteLine($"Index {index} = {GetFibonacciAtIndex(index)}");
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not a valid input!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
