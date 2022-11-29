using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Shared.Fifteen
{
    public class GamePiece : Piece
    {
        public static Color Correct { get; set; } = Color.Green;
        public static Color Incorrect { get; set; } = Color.Tan;
        public static Color Empty { get; set; } = Color.SlateGray;

        public bool IsCorrect { get; set; }
    }
}
