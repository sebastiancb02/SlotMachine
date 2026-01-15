namespace Slot_Machine;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Let’s play the SlotMachine Game!");
        Console.WriteLine("\nPlease, enter your amount of money to play, and then press ENTER:");
        int moneyCount = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("\nNow, please choose your configuration:");
        Console.WriteLine("\nPress 1 if you only want to play with the center line (cost: €X/per spin)");
        Console.WriteLine("Press 2 if you want to play with all the horizontal lines (cost: €Y/per spin)");
        Console.WriteLine("Press 3 if you want to play with all 3 horizontal lines + diagonals (cost: €Z/per spin)");

        int[,] slotMachineGrid = new int [3, 3];
        
        char userOption;

        while (moneyCount != 0)
        {
            userOption = Console.ReadKey(true).KeyChar;
	
            bool win = true;
            int centerLine = 3/2;

            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    Random rnd = new Random(); 
                    slotMachineGrid[row, column] = rnd.Next(1, 3);
                }
            }

            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    Console.WriteLine(slotMachineGrid[row, column]);
                }
            }

            if (userOption == '1')
            {

                if (slotMachineGrid[centerLine, 0] == slotMachineGrid[centerLine, 1])
                {
                    Console.WriteLine("Wow! You’ve just earned €3!");
                    //win;
                    moneyCount += 3;
                } 
 
                else
                {
                    Console.WriteLine("Bad luck :(");
                    moneyCount -= 1;
                }

            }
        }
    }
}