namespace ConSmallestNumber;

static class Program
{
    private static double GetSmallest(double num1, double num2, double num3)
    {
        if (num3 < num1 && num3 < num2)
            return num3;
        if (num2 < num1 && num2 < num3)
            return num2;
        if (num1 < num2 && num1 < num3)
            return num1;
        return num1;
    }
    
    private static double GetTerm(string index)
    {
        double term;
        while (true)
        {
            Console.Write($"Enter term {index}: ");
            try
            {
                term = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a number!");
                Console.ForegroundColor = ConsoleColor.White;
                continue;
            }

            break;
        }

        return term;
    }
    
    static void Main()
    {
        while (true)
        {
            Console.WriteLine();
            var term1 = GetTerm("1");
            var term2 = GetTerm("2");
            var term3 = GetTerm("3");
            
            Console.Clear();
            Console.WriteLine($"[ {term1}, {term2}, {term3} ]");
            Console.WriteLine($"Smallest number: { GetSmallest(term1, term2, term3) }");
        }
    }
}
