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

            double DistanceToPin = course.CourseLength - course.PlacementOfPin;

            Console.WriteLine("{0} is about to play his most important hole, ever.\n", player.Name);
            Console.WriteLine("Course length: {0}", course.CourseLength);
            Console.WriteLine("Distance to Pin: {0}", DistanceToPin.ToString("0.##"));

            double ShotAngle /*= Ball.CalcAngleInDegrees()*/;
            double ShotSpeed /*= Ball.CalcVelocity()*/;
            double ShotLength /*= ball.BallHit(ShotSpeed, ShotAngle)*/;
            string ContinueMessage = "";


            bool isAlive = true;
            while (isAlive)
            {
                ShotAngle = Ball.CalcAngleInDegrees();
                ShotSpeed = Ball.CalcVelocity();
                ShotLength = ball.BallHit(ShotSpeed, ShotAngle);
                ball.PlacementOfBall += ShotLength;
                DistanceToPin = (course.CourseLength - course.PlacementOfPin) - ball.PlacementOfBall;

                Console.WriteLine("Shot length: {0}", ShotLength.ToString("0.##"));
                
                Console.WriteLine("Total distance ball travelled: {0}", ball.PlacementOfBall.ToString("0.##"));

                try
                {
                    if (ball.PlacementOfBall < course.CourseLength)
                    {
                        if (ball.PlacementOfBall < course.CourseLength - course.PlacementOfPin)
                        {
                            throw new Exception("Ball not close enough to pin.");
                        }
                        else if (ball.PlacementOfBall > course.CourseLength - course.PlacementOfPin && ball.PlacementOfBall < course.CourseLength)
                        {
                            // Om bollen hamnar efter hålet men innan banans slut
                        }
                    }
                    else
                    {
                        ball.PlacementOfBall = 0.0;
                        //You loose!
                        throw new CustomException("Ball Out Of Bounds!");
                    }                
                }            
                catch (CustomException ex)
                {
                    //Handle exception Out Of Bound
                    Console.WriteLine("You loose!");
                    Console.WriteLine("Error: {0}", ex.Message);
                    ContinueMessage = "Play again?";
                }
                catch (Exception ex)
                {
                    // Handle exception Not Close Enough
                    Console.WriteLine("Still {0} meters from the Cup.", DistanceToPin.ToString("0.##"));
                    Console.WriteLine("New info: {0}", ex.Message);
                    ContinueMessage = "Next stroke?";

                }

                //Överkurs
                //Calc direction side-2-side OutOfBounds
                //Console.WriteLine(ball.CalcBallPlacement(0, 150));

                Console.WriteLine(ContinueMessage);
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
