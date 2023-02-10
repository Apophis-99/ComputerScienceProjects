
namespace ConAscii;

public static class Program
{
    private static byte GetInput()
    {
        while (true)
        {
            Console.Write("Enter a number between 0 and 255: ");
            try
            {
                var num = Convert.ToByte(Console.ReadLine());
                return num;
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You must enter a number between 0 and 255!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
    
    public static void Main()
    {
        while (true)
        {
            var num = GetInput();
            Console.WriteLine($"{ num }: { Convert.ToChar(num) }");
        }
    }
}
