using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGamev2
{
    public class Renderer
    {
        public char[][] buffer = new char[64][];

        public void CreateBuffer()
        {
            for (int i = 0; i < Console.WindowHeight; ++i) 
                buffer[i] = new char[Console.WindowWidth];
        }

        public void ClearBuffer()
        {
            for (int i = 0; i < Console.WindowHeight; ++i)
                buffer[i] = new char[Console.WindowWidth];
        } 
        public void DrawIntoBuffer(Cell _object, char _shape)
        {
            buffer[_object.y][_object.x] = _shape;
        }

        public void Draw()
        {
            Console.SetCursorPosition(0,0);
            Console.CursorVisible = false;
            for(int i = 0; i < Console.WindowHeight; ++i)
                Console.WriteLine(buffer[i]);
        }
    }
}
