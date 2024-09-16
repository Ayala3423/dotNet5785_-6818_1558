internal partial class Program
{
     private static void Main(string[] args)
    {
        Welcome6818();
        Welcome1558();
    }

    private static void Welcome6818()
    {
        Console.WriteLine("Enter Your Name");
        string name = Console.ReadLine();
        Console.WriteLine(name + ", welcome to my first console");
    }
    static partial void Welcome1558();
}