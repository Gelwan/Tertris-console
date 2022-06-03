using System.Timers;

namespace TertrisV2
{
    internal class Program
    {
        static List<Shape> shapes = new List<Shape>();
        static void Main(string[] args)
        {
            //Loop();
            Shape shape1 = new Shape(3, 3, 1);
            shapes.Add(shape1);
            shape1.shapeIntoBoard();
            while(true)
            {
                Board.printBoardTab();
                char key = Console.ReadKey().KeyChar;
                shape1.changePosition(key);
            }
        }
        static void Loop()
        {
            System.Timers.Timer loopTimer = new System.Timers.Timer();

            loopTimer.Interval = Rules.shapeDownTime;
            loopTimer.AutoReset = true;
            loopTimer.Elapsed += shapeDown;
            loopTimer.Start();
        }
        static void shapeDown(object source, System.Timers.ElapsedEventArgs a)
        {
            var x = shapes.Last<Shape>();
            //x.positionY++;
            x.changePosition('s');
            Board.printBoardTab();
        }

    }
}