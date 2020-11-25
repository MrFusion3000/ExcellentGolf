using System;

namespace ExcellentGolf
{
    class Program
    {
        static void Main()
        {
            Player player = new Player()
            {
                Name = "Ingolf Bramserud",

            };

            Course course = new Course()
            {
                CourseLength = 100,
                CourseWidth = 250,
                PlacementOfPin = 25
            };

            Ball ball = new Ball()
            {
                PlacementOfBall = 0
            };

            Console.WriteLine("{0} is about to play his most important hole, ever.", player.Name);

            bool isAlive = true;
            while (isAlive)
            {
                double ShotAngle = Ball.CalcAngleInDegrees();
                double ShotSpeed = Ball.CalcVelocity();

                double ShotLength = ball.BallHit(ShotSpeed, ShotAngle);

                Console.WriteLine(ShotLength);

                ball.PlacementOfBall += ShotLength;
                Console.WriteLine("Place on of ball: {0}", ball.PlacementOfBall);

                try
                {
                    if (ball.PlacementOfBall < course.CourseLength)
                    {
                        throw new Exception("Ball not close enough to pin.");                        
                    }
                    else
                    {
                        throw new CustomException("Ball Out Of Bounds!");
                    }                
                }            
                catch (CustomException ex)
                {
                    //Handle exception Not close enough
                    Console.WriteLine("Error: {0}", ex.Message);
                }
                catch (Exception ex)
                {
                    // Handle exception Out Of Bounds
                    Console.WriteLine("New info: {0}", ex.Message);
                }

                //Överkurs
                //Calc direction side-2-side OutOfBounds
                //Console.WriteLine(ball.CalcBallPlacement(0, 150));

                Console.WriteLine("Next stroke?");
                string playAgain = Console.ReadLine();

                if (playAgain == "n" || playAgain == "N")
                {
                    isAlive = false;
                }
                else
                {
                    //ball.PlacementOfBall = 0;
                }
            }
        }        
    }
}
