using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGamev2
{
    public class Game
    {

        public bool _gameOver = false;
        public Renderer _renderer = new Renderer();
        public Snake _snake = new Snake(5);
        public Cell _food = new Cell();
        public Random rand = new Random();
        public int _score = 0;

        public void Run()
        {
            _renderer.CreateBuffer();
            _food = new Cell(rand.Next(1, Console.WindowWidth - 2), rand.Next(1, Console.WindowHeight - 2));

            while (!_gameOver)
            {
                _renderer.ClearBuffer();
                _snake.Update();
                _snake.GetDirection();
                _snake.Move();

                if(GameOver()) break;

                if (_snake.head.isEqual(_food))
                {
                    ++_score;
                    _snake.Grow();
                    _food = new Cell(rand.Next(1, Console.WindowWidth - 2), rand.Next(1, Console.WindowHeight - 2));
                }

                //foreach (var part in _snake.body) if (part.isEqual(_snake.head)) _gameOver = true;
                _renderer.DrawIntoBuffer(_food, '*');
                foreach (var part in _snake.body) _renderer.DrawIntoBuffer(part, 'o');
                _renderer.DrawIntoBuffer(_snake.head, 'O');
                _renderer.Draw();
                Thread.Sleep(100);
            }

            Console.Clear();
            Console.WriteLine("GAMEOVER");
            Console.ReadKey();
        }

        public bool GameOver()
        {
            if (_snake.head.x < 0 || _snake.head.y < 0 || _snake.head.x > Console.WindowWidth || _snake.head.y > Console.WindowHeight) return true;
            foreach (var part in _snake.body) if (_snake.head.isEqual(part)) return true;
            return false;
        }

    }
}
