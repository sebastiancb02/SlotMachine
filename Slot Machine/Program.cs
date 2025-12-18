namespace Slot_Machine;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Let’s play the Slot Machine Game!");
        Console.WriteLine("\nPlease, enter your amount of money to play, and then press ENTER:");
        int moneyCount = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("\nNow, please choose your configuration:");
        Console.WriteLine("\nPress 1 if you only want to play with the center line (cost: €X/per spin)");
        Console.WriteLine("Press 2 if you want to play with all the horizontal lines (cost: €Y/per spin)");
        Console.WriteLine("Press 3 if you want to play with all 3 horizontal lines + diagonals (cost: €Z/per spin)");

        int[,] slotMachine = new int [3, 3];
    }
}