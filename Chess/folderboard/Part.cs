﻿using System;
using System.Drawing;

namespace folderboard
{
    class Part
    {
        public Position position { get; set; }
        public Color color { get; set; }
        public int quantityMoves { get; protected set; }
        public Board board { get; protected set; }

        public Part(Color color, Board board)
        {
            this.position = null;
            this.color = color;
            this.quantityMoves = 0;
            this.board = board;
        }


    }
}
