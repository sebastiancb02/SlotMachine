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
        const int LOWEST_POSSIBLE_NUMBER_IN_THE_GRID = 1;
        const int HIGHEST_POSSIBLE_NUMBER_IN_THE_GRID = 3;
        const char NEW_AMOUNT_OPTION = 'N';
        const char EXIT_OPTION = 'E';

        Console.WriteLine("Let’s play the SlotMachine Game!");
        Console.WriteLine("\nPlease, enter your amount of money to play, and then press ENTER:");
        int moneyCount = Convert.ToInt32(Console.ReadLine());

        int[,] slotMachineGrid = new int [GRID_SIZE, GRID_SIZE];

        char userOption;
        char noMoneyChoice;
        bool keepPlaying = true;
        Random rnd = new Random();

        while (keepPlaying)
        {
            while (moneyCount != 0)
            {
                Console.WriteLine("\nChoose your mode:");
                Console.WriteLine($"Press 1 if you only want to play with the center line (cost: €{MIDDLE_LINE_MODE_COST}/per spin)");
                Console.WriteLine($"Press 2 if you want to play with all the horizontal lines (cost: €{ALL_HORIZONTAL_LINES_MODE_COST}/per spin)");
                Console.WriteLine($"Press 3 if you want to play with all diagonals (cost: €{DIAGONAL_LINES_MODE_COST}/per spin)");
                Console.WriteLine();
                
                userOption = Console.ReadKey(true).KeyChar;
                
                Console.Clear();

                int centerLine = GRID_SIZE / 2;

                for (int row = 0; row < GRID_SIZE; row++)
                {
                    for (int column = 0; column < GRID_SIZE; column++)
                    {
                        slotMachineGrid[row, column] = rnd.Next(LOWEST_POSSIBLE_NUMBER_IN_THE_GRID, HIGHEST_POSSIBLE_NUMBER_IN_THE_GRID);
                    }
                }
                
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
                        Console.WriteLine($"\nWow! You've just earned €{MIDDLE_LINE_MODE_WIN}!");
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
                        Console.WriteLine($"\nWow! You've just earned €{ALL_HORIZONTAL_LINES_MODE_WIN}!");
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
                        Console.WriteLine($"\nWow! You've just earned €{DIAGONAL_LINES_MODE_WIN}!");
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
                    Console.WriteLine($"\nYou can either press '{NEW_AMOUNT_OPTION}' to insert a new amount or press '{EXIT_OPTION}' to QUIT");
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
                        Console.Clear();
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