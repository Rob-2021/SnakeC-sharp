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

        private Square Food = null;
        private Random oRandom = new Random();
        private int Points = 0;

        PictureBox oPicureBox;
        Label labelPoint;

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

        public Game(PictureBox oPictureBox, Label labelPoint)
        {
            this.oPicureBox = oPictureBox;
            this.labelPoint = labelPoint;
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

            Points = 0;
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

            //mostramos la comida
            if (Food != null)
                PaintPixel(bmp, Food.X, Food.Y, Color.Green);

            oPicureBox.Image = bmp;



            labelPoint.Text = "Puntos: " + Points.ToString();
        }

        public void Next()
        {
            if (Food == null)
                GetFood();

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
                case Direccion.Left:
                    {
                        if (Snake[0].X == 0)
                            Snake[0].X = lengthMap - 1;
                        else
                            Snake[0].X--;
                        break;
                    }
                case Direccion.Down:
                    {
                        if (Snake[0].Y == (lengthMap - 1))
                            Snake[0].Y = 0;
                        else
                            Snake[0].Y++;
                        break;
                    }
                case Direccion.Up:
                    {
                        if (Snake[0].Y == 0)
                            Snake[0].Y = lengthMap - 1;
                        else
                            Snake[0].Y--;
                        break;
                    }
            }

            SnakeEating();
        }

        private void SnakeEating()
        {
            if (Snake[0].X == Food.X && Snake[0].Y == Food.Y)
            {
                Food = null;
                Points++; //sumando puntos
            }
        }

        private void GetFood()
        {
            int X = oRandom.Next(0, lengthMap - 1);
            int Y = oRandom.Next(0, lengthMap - 1);

            Food = new Square(X, Y);
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
