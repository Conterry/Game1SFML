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

            GameLauchParams lauchParams = new GameLauchParams();
            lauchParams.SecondGamer = int.Parse(Console.ReadLine());

            Game NewGame = new Game(lauchParams);
            NewGame.Run();
        }
    }
}