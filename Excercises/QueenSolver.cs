using System;
using System.Collections.Generic;

namespace Excercises
{
    public static class QueenSolver
    {
        private static int PossibleSolutions = 0;
        private const int Size = 8;
        static int[,] board = new int[Size, Size];
        static HashSet<int> Rows = new HashSet<int>();
        static HashSet<int> Cols = new HashSet<int>();
        public static void Solve(int row = 0)
        {
            if (row == Size)
            {
                PrintSolution();
                return;
            }
            else
            {
                for (int col = 0; col < Size; col++)
                {
                    if(IsSafeToPlaceQueen(row, col))
                    {
                        MarkAttakedFields(row, col);
                        Solve(row + 1);
                        UnmarkAttakedFields(row, col);
                        
                    }
                }
            }
        }

        private static void PrintSolution()
        {
            int rowLength = board.GetLength(0);
            int colLength = board.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            PossibleSolutions++;
            Console.WriteLine(PossibleSolutions);
            
        }

        private static void UnmarkAttakedFields(int row, int col)
        {
            board[row, col] = 0;
            Rows.Remove(row);
            Cols.Remove(col);
        }

        private static void MarkAttakedFields(int row, int col)
        {
            board[row, col] = 1;
            Rows.Add(row);
            Cols.Add(col);
        }

        private static bool IsSafeToPlaceQueen(int row, int col)
        {
            if (Rows.Contains(row)) return false;
            if (Cols.Contains(col)) return false;
            // could be done better, but prefer to not :D 
            for (int i = 1; i < Size; i++)
            {
                int currentRow = row - 1;
                int currentCol = col - 1;

                if(currentRow<0 || currentRow>=Size || currentCol<0 || currentCol >= Size)
                {
                    break;
                }
                if(board[currentRow, currentCol] == 1)
                {
                    return false;
                }
            }
            for (int i = 1; i < Size; i++)
            {
                int currentRow = row + 1;
                int currentCol = col + 1;

                if (currentRow < 0 || currentRow >= Size || currentCol < 0 || currentCol >= Size)
                {
                    break;
                }
                if (board[currentRow, currentCol] == 1)
                {
                    return false;
                }
            }
            for (int i = 1; i < Size; i++)
            {
                int currentRow = row + 1;
                int currentCol = col - 1;

                if (currentRow < 0 || currentRow >= Size || currentCol < 0 || currentCol >= Size)
                {
                    break;
                }
                if (board[currentRow, currentCol] == 1)
                {
                    return false;
                }
            }
            for (int i = 1; i < Size; i++)
            {
                int currentRow = row - 1;
                int currentCol = col + 1;

                if (currentRow < 0 || currentRow >= Size || currentCol < 0 || currentCol >= Size)
                {
                    break;
                }
                if (board[currentRow, currentCol] == 1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
