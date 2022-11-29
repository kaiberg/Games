using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Shared.Fifteen
{
    public enum Move
    {
        UP, DOWN, LEFT, RIGHT
    }

    public class Game
    {
        public bool IsOver { get; private set; } = false;
        public int COUNT => DIMENSION_SIZE*DIMENSION_SIZE;
        public int DIMENSION_SIZE { get; private set; }
        public int EmptyRow { get; private set; }
        public int EmptyColumn { get; private set; }
        public GamePiece[,] Board { get; private set; }  
        public Game(int size)
        {
            DIMENSION_SIZE = size;
            Board = new GamePiece[DIMENSION_SIZE, DIMENSION_SIZE];
            for (int i = 0; i < DIMENSION_SIZE; i++)
                for (int j = 0; j < DIMENSION_SIZE; j++)
                    Board[i,j] = new() { Number = i * DIMENSION_SIZE + j + 1, IsCorrect = true };

            EmptyColumn = DIMENSION_SIZE-1;
            EmptyRow = DIMENSION_SIZE-1;
        }
        // Sets up a game with the specified amount of pieces
        // scrambled with the seed
        public Game(int count, string seed) : this(count) => scramble(seed);

        public void Swap(Move m)
        {
            int r = EmptyRow, c = EmptyColumn;
            switch (m)
            {
                case Move.UP:
                    r = r - 1;
                    break;
                case Move.DOWN:
                    r = r + 1;
                    break;
                case Move.LEFT:
                    c = c - 1;
                    break;
                case Move.RIGHT:
                    c = c + 1;
                    break;
            }
            if (r >= 0 && r < DIMENSION_SIZE && c >= 0 && c < DIMENSION_SIZE)
            {
                (Board[r,c], Board[EmptyRow, EmptyColumn]) = (Board[EmptyRow, EmptyColumn], Board[r,c]);
                (EmptyRow, EmptyColumn) = (r, c);
                appropriate();
            }
        }

        private void scramble(string seed)
        {
            foreach (char c in seed)
            {
                int n = c;
                while (n != 0)
                {
                    Move m;
                    int digit = Helper.LastDigit(n);
                    if (digit < 5)
                        m = (digit % 2 == 0)
                            ? Move.UP
                            : Move.DOWN;
                    else
                        m = (digit % 2 == 0) 
                            ? Move.LEFT
                            : Move.RIGHT;
                    Swap(m);
                    n = Helper.RemoveLastDigit(n);
                }

            }
        }

        private void appropriate()
        {
            bool over = true;
            for (int i = 0; i < DIMENSION_SIZE; i++)
                for (int j = 0; j < DIMENSION_SIZE; j++)
                {
                    bool isCorrect = Board[i,j].Number == i * DIMENSION_SIZE + j + 1;
                    Board[i,j].IsCorrect = isCorrect;
                    if (!isCorrect)
                        over = false;
                }
            IsOver = over;
        }
    }
}
