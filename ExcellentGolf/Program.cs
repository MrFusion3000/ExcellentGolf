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
                CourseLength = 100.0,
                CourseWidth = 250.0,
                PlacementOfPin = 25.0
            };

            Ball ball = new Ball()
            {
                PlacementOfBall = 0.0
            };

            Console.WriteLine("{0} is about to play his most important hole, ever.\n", player.Name);

            bool isAlive = true;
            while (isAlive)
            {
                double ShotAngle = Ball.CalcAngleInDegrees();
                double ShotSpeed = Ball.CalcVelocity();

                double ShotLength = ball.BallHit(ShotSpeed, ShotAngle);

                Console.WriteLine("Shot length: {0}", ShotLength);
                Console.WriteLine("Distance to Pin: {0}", course.CourseLength-course.PlacementOfPin);
                ball.PlacementOfBall += ShotLength;
                Console.WriteLine("Place on of ball: {0}", ball.PlacementOfBall);

                try
                {
                    if (ball.PlacementOfBall < course.CourseLength)
                    {
                        if (ball.PlacementOfBall < course.CourseLength - course.PlacementOfPin)
                        {
                            throw new CustomException("Ball not close enough to pin.", ball, ShotLength);
                        }
                    }
                    else
                    {
                        ball.PlacementOfBall = 0.0;
                        Console.WriteLine("You loose!");
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
