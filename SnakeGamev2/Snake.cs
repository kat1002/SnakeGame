using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGamev2
{
    public class Snake
    {
        public Cell head;
        public List<Cell> body = new List<Cell>();
        public Direction dir = Direction.RIGHT;

        public Snake(int _length)
        {
            head = new Cell(1, 1);
            for(int i = 2; i <= _length + 1; ++i) body.Add(new Cell(1, i));
        }

        public void Update()
        {
            Cell newhead = new Cell(head.x, head.y);
            body.Insert(0, newhead);
            body.RemoveAt(body.Count - 1);
        }

        public void Grow()
        {
            body.Add(new Cell(0, 0));
        }

        public void GetDirection()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();

                if (userInput.Key == ConsoleKey.UpArrow || userInput.Key == ConsoleKey.W)
                {
                    if (dir != Direction.DOWN && dir != Direction.UP) dir = Direction.UP;
                }
                else if (userInput.Key == ConsoleKey.DownArrow || userInput.Key == ConsoleKey.S)
                {
                    if (dir != Direction.DOWN && dir != Direction.UP) dir = Direction.DOWN;
                }
                else if (userInput.Key == ConsoleKey.LeftArrow || userInput.Key == ConsoleKey.A)
                {
                    if (dir != Direction.LEFT && dir != Direction.RIGHT) dir = Direction.LEFT;
                }
                else if (userInput.Key == ConsoleKey.RightArrow || userInput.Key == ConsoleKey.D)
                {
                    if (dir != Direction.LEFT && dir != Direction.RIGHT) dir = Direction.RIGHT;
                }
            }
        }

        public void Move()
        {
            if (dir == Direction.UP) head.y--;
            else if(dir == Direction.DOWN) head.y++;
            else if(dir == Direction.LEFT) head.x--;
            else if(dir == Direction.RIGHT) head.x++;
        }


    }
}
