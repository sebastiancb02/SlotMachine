namespace Slot_Machine;

class Program
{
    static void Main(string[] args)
    {
        const int GRID_SIZE = 3;
        const char MIDDLE_LINE_MODE = '1';
        const char ALL_HORIZONTAL_LINES_MODE = '2';
        const char DIAGONAL_LINES_MODE = '3';
        const int MIDDLE_LINE_MODE_WIN = 3;
        const int ALL_HORIZONTAL_LINES_MODE_WIN = 9;
        const int DIAGONAL_LINES_MODE_WIN = 12;
        const int MIDDLE_LINE_MODE_COST = 1;
        const int ALL_HORIZONTAL_LINES_MODE_COST = 3;
        const int DIAGONAL_LINES_MODE_COST = 5;
        const char NEW_AMOUNT_OPTION = 'N';
        const char EXIT_OPTION = 'E';

        Console.WriteLine("Let’s play the SlotMachine Game!");
        Console.WriteLine("\nPlease, enter your amount of money to play, and then press ENTER:");
        int moneyCount = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("\nNow, please choose your configuration:");
        Console.WriteLine("\nPress 1 if you only want to play with the center line (cost: €1/per spin)");
        Console.WriteLine("Press 2 if you want to play with all the horizontal lines (cost: €3/per spin)");
        Console.WriteLine("Press 3 if you want to play with all diagonals (cost: €5/per spin)");

        int[,] slotMachineGrid = new int [GRID_SIZE, GRID_SIZE];

        char userOption;
        char noMoneyChoice;
        bool keepPlaying = true;

        while (keepPlaying)
        {
            while (moneyCount != 0)
            {
                userOption = Console.ReadKey(true).KeyChar;

                int centerLine = GRID_SIZE / 2;

                for (int row = 0; row < GRID_SIZE; row++)
                {
                    for (int column = 0; column < GRID_SIZE; column++)
                    {
                        Random rnd = new Random();
                        slotMachineGrid[row, column] = rnd.Next(1, 3);
                    }
                }

                Console.Clear();
                Console.WriteLine("\nPress 1 if you only want to play with the center line (cost: €1/per spin)");
                Console.WriteLine("Press 2 if you want to play with all the horizontal lines (cost: €3/per spin)");
                Console.WriteLine("Press 3 if you want to play with all diagonals (cost: €5/per spin)");
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

                if (userOption == MIDDLE_LINE_MODE)
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
                        moneyCount += MIDDLE_LINE_MODE_WIN;
                    }

                    else
                    {
                        Console.WriteLine("\nBad luck :(");
                        moneyCount -= MIDDLE_LINE_MODE_COST;
                    }
                }

                if (userOption == ALL_HORIZONTAL_LINES_MODE)
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
                        moneyCount += ALL_HORIZONTAL_LINES_MODE_WIN;
                    }

                    else
                    {
                        Console.WriteLine("\nBad luck :(");
                        moneyCount -= ALL_HORIZONTAL_LINES_MODE_COST;
                    }
                }

                if (userOption == DIAGONAL_LINES_MODE)
                {
                    bool mainDiagonalWin = true;
                    bool secondaryDiagonalWin = true;

                    for (int row = 0; row < GRID_SIZE; row++)
                    {
                        if (slotMachineGrid[0, 0] != slotMachineGrid[row, row])
                        {
                            mainDiagonalWin = false;
                        }
                    }

                    for (int row = 0; row < GRID_SIZE; row++)
                    {
                        if (slotMachineGrid[0, GRID_SIZE - 1] != slotMachineGrid[row, GRID_SIZE - row - 1])
                        {
                            secondaryDiagonalWin = false;
                        }
                    }

                    if (mainDiagonalWin && secondaryDiagonalWin)
                    {
                        Console.WriteLine("\nWow! You've just earned €12!");
                        moneyCount += DIAGONAL_LINES_MODE_WIN;
                    }

                    else
                    {
                        Console.WriteLine("\nBad luck :(");
                        moneyCount -= DIAGONAL_LINES_MODE_COST;
                    }
                }
                
                if (moneyCount <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("\nSorry, you've run out of money :,(");
                    Console.WriteLine("\nYou can either press 'N' to insert a new amount or press 'E' to QUIT");
                    noMoneyChoice = char.ToUpper(Console.ReadKey(true).KeyChar);
		
                    if (noMoneyChoice == NEW_AMOUNT_OPTION)
                    {
                        Console.WriteLine("\nPlease insert a new amount and press ENTER:");
                        string input = Console.ReadLine();
                        int moreMoney; 
                        bool valid = int.TryParse(input, out moreMoney);
                        
                        if (!valid)  
                        {
                            Console.WriteLine("\nInvalid input! \nPlease, enter a number");
                        }    
                        
                        moneyCount = moreMoney;
                    }	

                    if (noMoneyChoice == EXIT_OPTION)
                    {
                        Console.WriteLine("\nThank you for playing! We hope to see you soon :D");
                        keepPlaying = false;
                        break;
                    }
                }    

                Console.WriteLine($"\nAmount of money: {moneyCount}");
            }
        }
    }
}