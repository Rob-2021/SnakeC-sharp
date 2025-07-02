using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC_
{
    public class Game
    {
        public int scale = 10;
        public int lengthMap = 30;
        private int[,] squares;
        private List<Square> Snake;

        public enum Direccion { Right, Left, Up, Down };
        public Direccion ActualDirection = Direccion.Right;

        PictureBox oPicureBox;

        private int InitialPositionX
        {
            get
            {
                return lengthMap / 2;
            }
        }

        private int InitialPositionY
        {
            get
            {
                return lengthMap / 2;
            }
        }

        public Game(PictureBox oPictureBox)
        {
            this.oPicureBox = oPictureBox;
            Reset();
        }
        
        public void Reset()
        {
            Snake = new List<Square>();
            Square oInitialSquare = new Square(InitialPositionX, InitialPositionY);
            Snake.Add(oInitialSquare);

            squares = new int[lengthMap, lengthMap];

            for (int j = 0; j < lengthMap; j++)
            {
                for (int i = 0; i < lengthMap; i++)
                {
                    squares[i, j] = 0;
                }
            }
        }

        public void Show()
        {
            Bitmap bmp = new Bitmap(oPicureBox.Width, oPicureBox.Height);
            for (int j = 0; j < lengthMap; j++)
            {
                for (int i = 0; i < lengthMap; i++)
                {
                    if (Snake.Where(d=>d.X==i && d.Y==j).Count()>0)
                        PaintPixel(bmp, i, j, Color.Black);
                    else
                        PaintPixel(bmp, i, j, Color.White);
                }
            }

            oPicureBox.Image = bmp;
        }

        public void Next()
        {
            switch (ActualDirection)
            {
                case Direccion.Right:
                    {
                        if (Snake[0].X == (lengthMap - 1))
                            Snake[0].X = 0;
                        else
                            Snake[0].X++;
                        break;
                    }                   
            }
        }

        private void PaintPixel(Bitmap bmp, int x, int y, Color color)
        {
            for (int j = 0; j < scale; j++)
                for (int i = 0; i < scale; i++)
                    bmp.SetPixel(j+(x*scale), i+(y*scale), color);
        }

    }

    public class Square
    {
        public int X, Y;
        public Square(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
