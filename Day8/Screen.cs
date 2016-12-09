using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    public class Screen: IScreen
    {
        public int Height { get; set; }

        public int Width { get; set; }

        public bool[][] ScreenArray { get; set; }

        public Screen(int height, int width)
        {
            Height = height;
            Width = width;

            ScreenArray = new bool[Height][];
            for (int i = 0; i < Height; i++)
            {
                ScreenArray[i] = new bool[Width];
            }

        }

        public Screen(): this(6, 50){ }


        public void DrawRectangle(int width, int height)
        {
            if (width <= Width && height <= Height)
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        ScreenArray[i][j] = true;
                    }
                }
            }

        }

        public void RotateColumn(int column, int amount)
        {
            if (amount > Height)
                amount = amount%Height;
            
            var targetArray = new bool[Height];

            for (int i = 0; i < Height; i++)
            {
                if (amount + i > Height)
                    targetArray[(i+amount)-Height] = ScreenArray[i][column];
                
                else if(amount + i == Height)
                    targetArray[0] = ScreenArray[i][column];
                
                else 
                    targetArray[i+amount] = ScreenArray[i][column];
            }

            for(int i = 0; i < Height; i++)
            {
                ScreenArray[i][column] = targetArray[i];
            }
        }

        public void RotateRow(int row, int amount)
        {
            if (amount > Width)
                amount = amount%Width;

            var sourceArray = ScreenArray[row];
            var targetArray = new bool[Width];

            for (int i = 0; i < Width; i++)
            {
                if (amount + i > Width)
                    targetArray[(i + amount) - Width] = sourceArray[i];

                else if (amount + i == Width)
                    targetArray[0] = sourceArray[i];

                else
                    targetArray[i + amount] = sourceArray[i];
            }

            ScreenArray[row] = targetArray;
        

        }

        public string PrintScreen()
        {
            char mark = 'X';
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (ScreenArray[i][j])
                        sb.Append(mark);
                    else
                        sb.Append(' ');
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
