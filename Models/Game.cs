using System;

namespace TicTacGame.WindowsApp.Models
{
    public class Game
    {
        public string[,] Board { get; set; }
        public string PlayerName { get; set; }
        public string PlayerSymbol { get; set; }
        public string ComputerSymbol { get; set; }
        public string GameStatus { get; set; }

        public Game()
        {
            Board = new string[3, 3];
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Board[row, col] = string.Empty;
                }
            }
        }

        public bool MakeMove(int row, int col, string symbol)
        {
            if (string.IsNullOrEmpty(Board[row, col]))
            {
                Board[row, col] = symbol;
                return true;
            }

            return false;
        }

        public bool CheckWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (!string.IsNullOrEmpty(Board[i, 0]) &&
                    Board[i, 0] == Board[i, 1] &&
                    Board[i, 0] == Board[i, 2])
                    return true;

                if (!string.IsNullOrEmpty(Board[0, i]) &&
                    Board[0, i] == Board[1, i] &&
                    Board[0, i] == Board[2, i])
                    return true;
            }

            if (!string.IsNullOrEmpty(Board[0, 0]) &&
                Board[0, 0] == Board[1, 1] &&
                Board[0, 0] == Board[2, 2])
                return true;

            if (!string.IsNullOrEmpty(Board[0, 2]) &&
                Board[0, 2] == Board[1, 1] &&
                Board[0, 2] == Board[2, 0])
                return true;

            return false;
        }

        public bool CheckDraw()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (string.IsNullOrEmpty(Board[row, col]))
                        return false;
                }
            }

            return true;
        }

        public Tuple<int, int> GetComputerMove()
        {
            Random random = new Random();

            int row, col;
            do
            {
                row = random.Next(0, 3);
                col = random.Next(0, 3);
            } while (!string.IsNullOrEmpty(Board[row, col]));

            return Tuple.Create(row, col);
        }
    }
}
