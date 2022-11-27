using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGamev2
{
    public class Cell
    {
        public int x;
        public int y;

        public Cell() { }

        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool isEqual(Cell _object)
        {
            return ((_object.x == x) && (_object.y == y));
        }
    }
}
