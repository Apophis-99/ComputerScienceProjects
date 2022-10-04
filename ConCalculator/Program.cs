namespace ConCalculator;

static class Program
{
    private static void PrintMenu()
    {
        Console.WriteLine();
        Console.WriteLine("1. Add");
        Console.WriteLine("2. Subtract");
        Console.WriteLine("3. Multiply");
        Console.WriteLine("4. Divide");
        Console.WriteLine("5. Modulus");
        Console.WriteLine();
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
            PrintMenu();
            int option;
            while (true)
            {
                Console.Write("Enter choice (1-5): ");
                try
                {
                    option = Convert.ToInt16(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a number!");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                if (option is > 5 or < 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter a number between 1 and 5!");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                break;
            }

            Console.Clear();
            Console.WriteLine("Operator: " + 
                              (option switch
                              {
                                  1 => "Add",
                                  2 => "Subtract",
                                  3 => "Multiply",
                                  4 => "Divide",
                                  5 => "Modulus"
                              }));

            double term1 = GetTerm("1");
            double term2 = GetTerm("2");
            
            Console.Clear();
            Console.WriteLine($"{term1} {(option switch { 1 => "+", 2 => "-", 3 => "*", 4 => "/", 5 => "%" })} {term2} = {(option switch { 1 => term1 + term2, 2 => term1 - term2, 3 => term1 * term2, 4 => term1 / term2, 5 => term1 % term2})}");

        }
    }
}
