using System;

namespace _02.HelpAMole
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] field = new char[size, size];

            int moleRow = 0;
            int moleCol = 0;

            int fieldPoints = 0;
            int molePoints = 0;
            bool isWon = false;

            for (int row = 0; row < field.GetLength(0); row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = line[col];
                    if (line[col] == 'M')
                    {
                        moleRow = row;
                        moleCol = col;
                    }
                }
            }

            string cmd = Console.ReadLine();
            while (cmd != "End")
            {
                if (cmd == "up")
                {
                    if (ValidationIndex(moleRow - 1, moleCol, field))
                    {
                        field[moleRow, moleCol] = '-';
                        var value = field[moleRow - 1, moleCol].ToString();
                        if (int.TryParse(value, out fieldPoints))
                        {
                            moleRow--;
                            molePoints += fieldPoints;
                            field[moleRow, moleCol] = 'M';

                            if (molePoints >= 25)
                            {
                                isWon = true;
                                break;
                            }
                        }
                        else if (field[moleRow - 1, moleCol] == 'S')
                        {
                            field[moleRow - 1, moleCol] = '-';
                            MoveToSpecialLocation(field, ref moleRow, ref moleCol);
                            molePoints -= 3;
                            field[moleRow, moleCol] = 'M';
                        }
                        else
                        {
                            field[moleRow, moleCol] = '-';
                            moleRow--;
                            field[moleRow, moleCol] = 'M';
                        }
                    }
                    else
                    {
                        Console.WriteLine(EscapeWarning());
                    }
                }
                else if (cmd == "down")
                {
                    if (ValidationIndex(moleRow + 1, moleCol, field))
                    {
                        field[moleRow, moleCol] = '-';
                        var value = field[moleRow + 1, moleCol].ToString();
                        if (int.TryParse(value, out fieldPoints))
                        {
                            moleRow++;
                            molePoints += fieldPoints;
                            field[moleRow, moleCol] = 'M';

                            if (molePoints >= 25)
                            {
                                isWon = true;
                                break;
                            }
                        }
                        else if (field[moleRow + 1, moleCol] == 'S')
                        {
                            field[moleRow + 1, moleCol] = '-';
                            MoveToSpecialLocation(field, ref moleRow, ref moleCol);
                            molePoints -= 3;
                            field[moleRow, moleCol] = 'M';
                        }
                        else
                        {
                            field[moleRow, moleCol] = '-';
                            moleRow++;
                            field[moleRow, moleCol] = 'M';
                        }
                    }
                    else
                    {
                        Console.WriteLine(EscapeWarning());
                    }
                }
                else if (cmd == "left")
                {
                    if (ValidationIndex(moleRow, moleCol - 1, field))
                    {
                        field[moleRow, moleCol] = '-';
                        var value = field[moleRow, moleCol - 1].ToString();
                        if (int.TryParse(value, out fieldPoints))
                        {
                            moleCol--;
                            molePoints += fieldPoints;
                            field[moleRow, moleCol] = 'M';

                            if (molePoints >= 25)
                            {
                                isWon = true;
                                break;
                            }
                        }
                        else if (field[moleRow, moleCol - 1] == 'S')
                        {
                            field[moleRow, moleCol - 1] = '-';
                            MoveToSpecialLocation(field, ref moleRow, ref moleCol);
                            molePoints -= 3;
                            field[moleRow, moleCol] = 'M';
                        }
                        else
                        {
                            field[moleRow, moleCol] = '-';
                            moleCol--;
                            field[moleRow, moleCol] = 'M';
                        }
                    }
                    else
                    {
                        Console.WriteLine(EscapeWarning());
                    }
                }
                else if (cmd == "right")
                {
                    if (ValidationIndex(moleRow, moleCol + 1, field))
                    {
                        field[moleRow, moleCol] = '-';
                        var value = field[moleRow, moleCol + 1].ToString();
                        if (int.TryParse(value, out fieldPoints))
                        {
                            moleCol++;
                            molePoints += fieldPoints;
                            field[moleRow, moleCol] = 'M';

                            if (molePoints >= 25)
                            {
                                isWon = true;
                                break;
                            }
                        }
                        else if (field[moleRow, moleCol + 1] == 'S')
                        {
                            field[moleRow, moleCol + 1] = '-';
                            MoveToSpecialLocation(field, ref moleRow, ref moleCol);
                            molePoints -= 3;
                            field[moleRow, moleCol] = 'M';
                        }
                        else
                        {
                            field[moleRow, moleCol] = '-';
                            moleCol++;
                            field[moleRow, moleCol] = 'M';
                        }
                    }
                    else
                    {
                        Console.WriteLine(EscapeWarning());
                    }
                }

                cmd = Console.ReadLine();
            }

            if (isWon)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {molePoints} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {molePoints} points.");
            }

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void MoveToSpecialLocation(char[,] matrix, ref int moleRow, ref int moleCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        moleRow = row;
                        moleCol = col;
                        return;
                    }
                }
            }
        }

        private static bool ValidationIndex(int row, int col, char[,] matix)
        {
            return
                row >= 0 && row < matix.GetLength(0) && col >= 0 && col < matix.GetLength(1);
        }

        private static string EscapeWarning() => "Don't try to escape the playing field!";
    }
}
