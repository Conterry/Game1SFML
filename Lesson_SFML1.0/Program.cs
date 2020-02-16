using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace Lesson_SFML1._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 - играть с ботом");
            Console.WriteLine("2 - играть с другом");
            GameLaunchParams lauchParams = new GameLaunchParams();
            lauchParams.SecondGamer = int.Parse(Console.ReadLine());

            Game NewGame = new Game(lauchParams);
            NewGame.Run();
        }
    }
}