using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    public interface IScreen
    {
        void DrawRectangle(int width, int height);

        void RotateRow(int row, int amount);

        void RotateColumn(int column, int amount);
    }
}
