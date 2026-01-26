namespace Slot_Machine;

class Program
{
    static void Main(string[] args)
    {
        const int GRID_SIZE = 3;
        
        Console.WriteLine("Let’s play the SlotMachine Game!");
        Console.WriteLine("\nPlease, enter your amount of money to play, and then press ENTER:");
        int moneyCount = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("\nNow, please choose your configuration:");
        Console.WriteLine("\nPress 1 if you only want to play with the center line (cost: €1/per spin)");
        Console.WriteLine("Press 2 if you want to play with all the horizontal lines (cost: €3/per spin)");
        Console.WriteLine("Press 3 if you want to play with all diagonals (cost: €5/per spin)");

        int[,] slotMachineGrid = new int [3, 3];
        
        char userOption;

        while (moneyCount != 0)
        {
            userOption = Console.ReadKey(true).KeyChar;
            
            int centerLine = GRID_SIZE/2;

            for (int row = 0; row < GRID_SIZE; row++)
            {
                for (int column = 0; column < GRID_SIZE; column++)
                {
                    Random rnd = new Random(); 
                    slotMachineGrid[row, column] = 1;
                }
            }
            
            Console.WriteLine();

            for (int row = 0; row < GRID_SIZE; row++)
            {
                for (int column = 0; column < GRID_SIZE; column++)
                {
                    Console.Write(slotMachineGrid[row, column]);
                }
                
                Console.WriteLine();
            }
            
            bool win = true;

            if (userOption == '1')
            {
                for (int column = 0; column < GRID_SIZE; column++)
                {
                    if (slotMachineGrid[centerLine, 0] != slotMachineGrid[centerLine, column])
                    {
                        win = false;
                    } 
                }
                
                if (win)
                {    
                    Console.WriteLine("\nWow! You've just earned €3!");
                    moneyCount += 3;
                }
                
                else
                {
                    Console.WriteLine("\nBad luck :(");
                    moneyCount -= 1;
                }
            }

            if (userOption == '2')
            {
                for (int row = 0; row < GRID_SIZE; row++)
                {
                    for (int column = 0; column < GRID_SIZE; column++)
                    {
                        if (slotMachineGrid[row, 0] != slotMachineGrid[row, column])
                        {
                            win = false;
                        }
                    } 
                }
                
                if (win)
                {    
                    Console.WriteLine("\nWow! You've just earned €9!");
                    moneyCount += 9;
                }
                
                else
                {
                    Console.WriteLine("\nBad luck :(");
                    moneyCount -= 3;
                }
            }

            if (userOption == '3')
            {
                for (int row = 0; row < GRID_SIZE; row++)
                {
                    for (int column = 0; column < GRID_SIZE; column++)
                    {
                        if (slotMachineGrid[0, 0] != slotMachineGrid[row, row] && slotMachineGrid[0,GRID_SIZE - 1] != slotMachineGrid[row, column = GRID_SIZE - row - 1])
                        {
                            win = false;
                        }
                    } 
                }
                
                if (win)
                {    
                    Console.WriteLine("\nWow! You've just earned €12!");
                    moneyCount += 12;
                }
                
                else
                {
                    Console.WriteLine("\nBad luck :(");
                    moneyCount -= 3;
                }    
            }    
            
            Console.WriteLine($"\nAmount of money left: {moneyCount}");
            
            if (moneyCount == 0)
            {
                Console.WriteLine("\nSorry, you've run out of money");
            }
        }
    }
}