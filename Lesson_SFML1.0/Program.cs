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
            Game NewGame = new Game();
            NewGame.Run();
        }
    }

    class Game 
    { 
        private RenderWindow window;
        private CircleShape Circle;
        private CircleShape Rectangle1;
        private Vector2f circleVelocity; // tipo speed toka vector
        private Vector2f rectangleVelocity;

        private void Init()
        {
            Circle = new CircleShape(CircleSize);
            Rectangle1 = new CircleShape(CircleSize);
            Rectangle1.FillColor = Color.Black;
            Circle.FillColor = Color.White;
            Circle.Position = new Vector2f(FieldSizeX / 2, FieldSizeY / 2);
            Rectangle1.Position = new Vector2f(10, FieldSizeY / 2);
            SetCircleStartVector();
            SetRectangleStartVector();
            
            window = new RenderWindow(new VideoMode(FieldSizeX, FieldSizeY), "Почти игра");
            window.Closed += WindowClosed;

            window.SetFramerateLimit((uint)TARGET_FPS);
        }

        public const int CircleSize = 30;
        private bool ExitKeyPressed;
        private const float RectangleX = 5;
        private const float RectangleY = 50;
        public const int FieldSizeX = 1600;
        public const int FieldSizeY = 900;
        public const float TARGET_FPS = 120f;
        private float timeStep = 1/ TARGET_FPS;
        public int ControlPressed = 0;
        public int NewControlPressed = 0;

        public void Run()
        {
            Init();

            while (WindowIsActive())
            {
                GetInput();

                Logyc();

                Draw();
            }
        }

        private bool WindowIsActive()
        {
            return window.IsOpen && !ExitKeyPressed;
        }

        void SetCircleStartVector()
        {
            float x = 400f;
            float y = 300f;
            circleVelocity = new Vector2f(x, y);
        }

        void SetRectangleStartVector()
        {
            float x = 0f;
            float y = 300f;
            rectangleVelocity = new Vector2f(x, y);
        }

        void GetInput()
        {
            // check input events
            window.DispatchEvents();

            if(Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                ExitKeyPressed = true;
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                NewControlPressed += 1;
            }

        }

        void Logyc()
        {
            Circle.Position += circleVelocity * 2 * timeStep;
            Rectangle1.Position += rectangleVelocity * timeStep;

            if(Circle.Position.X + 2*CircleSize > FieldSizeX && circleVelocity.X > 0)
            {
                circleVelocity.X *= -1;
            }

            if (Circle.Position.Y + 2*CircleSize > FieldSizeY && circleVelocity.Y > 0)
            {
                circleVelocity.Y *= -1;
            }

            if (Circle.Position.Y < 0 && circleVelocity.Y < 0)
            {
                circleVelocity.Y *= -1;
            }

            if (NewControlPressed > ControlPressed || Rectangle1.Position.Y < 0 || Rectangle1.Position.Y > FieldSizeY - CircleSize*2)
            {
                rectangleVelocity.Y *= -1;
                ControlPressed = NewControlPressed;
                //отбитие от стен и на кнопку "W"
            }

            if (Circle.Position.X < Rectangle1.Position.X + 2*CircleSize  && Rectangle1.Position.Y - 3 * CircleSize < Circle.Position.Y && 2*Rectangle1.Position.Y > Circle.Position.Y + CircleSize)
            {
                circleVelocity.X *= -1;
            }

            if(Circle.Position.X < 0)
            {
                circleVelocity *= 0;
                rectangleVelocity *= 0;
            }

        }

        void Draw()
        {
            window.Clear(Color.Green);

            Circle.Draw(window, RenderStates.Default);

            Rectangle1.Draw(window, RenderStates.Default);

            window.Display();
        }

        void WindowClosed(object sender, EventArgs e)
        {
            RenderWindow w = (RenderWindow)sender;
            w.Close();
        }

    }
}