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
                PlacementOfPin = 25.0,
                MaxStrokes = 5
            };

            Ball ball = new Ball()
            {
                PlacementOfBall = 0.0
            };

            double DistanceToPin = course.CourseLength - course.PlacementOfPin;

            Console.WriteLine("{0} is about to play his most important hole, ever.\n", player.Name);
            Console.WriteLine("Course length: {0}", course.CourseLength);
            Console.WriteLine("Distance to Pin: {0}", DistanceToPin.ToString("0.##"));

            double ShotAngle;
            double ShotSpeed;
            double ShotLength;
            string ContinueMessage = "";

            bool isAlive = true;
            while (isAlive)
            {
                ShotAngle = Ball.CalcAngleInDegrees();
                ShotSpeed = Ball.CalcVelocity();
                ShotLength = ball.BallHit(ShotSpeed, ShotAngle);
                player.Strokes++;

                Console.WriteLine("Shot length: {0}", ShotLength.ToString("0.##"));

                try
                {
                    // Check if ball is between cup and end of course
                    if (ball.PlacementOfBall > course.CourseLength - course.PlacementOfPin && ball.PlacementOfBall < course.CourseLength)
                    {
                        ShotLength *= -1;
                    }
                    else
                    {
                        ShotLength *= 1;
                    }

                    ball.PlacementOfBall += ShotLength;
                    DistanceToPin = (course.CourseLength - course.PlacementOfPin) - ball.PlacementOfBall;

                    Console.WriteLine("Player number of strokes: {0}", player.Strokes);
                    Console.WriteLine("Total distance ball travelled: {0}", ball.PlacementOfBall.ToString("0.##"));

                    // Ball still on the course?
                    if (ball.PlacementOfBall < course.CourseLength)
                    {
                        // Ball close enough to pin?
                        if (ball.PlacementOfBall <= (course.CourseLength - course.PlacementOfPin) - 1 || ball.PlacementOfBall <= (course.CourseLength - course.PlacementOfPin) + 1)
                        {
                            Console.WriteLine("YES!");
                            throw new Exception("It's in the hole!");
                        }
                        if (ball.PlacementOfBall < course.CourseLength - course.PlacementOfPin)
                        {
                            Console.WriteLine("You passed the pin by {0} meters.", (DistanceToPin).ToString("0.##"));
                            //Console.WriteLine("Bollen ligger {0} på banan", ball.PlacementOfBall);
                            //ContinueMessage = "Next stroke?";
                        }
                        // Ball between pin and end of course?
                        else if (ball.PlacementOfBall > course.CourseLength - course.PlacementOfPin && ball.PlacementOfBall < course.CourseLength)
                        {                            
                            Console.WriteLine("You passed the pin by {0} meters.", (DistanceToPin *= -1).ToString("0.##"));
                            //Console.WriteLine("Bollen ligger {0} på banan", ball.PlacementOfBall);
                            /*ContinueMessage = "Next stroke?";*/
                        }
                        ContinueMessage = "Next stroke?";
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
                    // Handle exception Out Of Bounds
                    Console.WriteLine("You loose!");
                    Console.WriteLine("Error 1: {0}", ex.Message);
                    ContinueMessage = "Play again?";
                }
                catch (Exception ex)
                {
                    // Handle exception Not Close Enough
                    Console.WriteLine("Still {0} meters from the Cup.", DistanceToPin.ToString("0.##"));
                    Console.WriteLine("New info: {0}", ex.Message);
                    ContinueMessage = "Next stroke?";
                }

                try
                {
                    if (player.Strokes >= course.MaxStrokes)
                    {
                        throw new ToManyStrokesException("Sorry, you reached the stroke limit for this course!");
                    }
                }
                catch (ToManyStrokesException ex)
                {
                    ContinueMessage = "Play again?";
                    Console.WriteLine("Erro 2: {0}", ex.Message);
                }

                Console.WriteLine(ContinueMessage);
                string playAgain = Console.ReadLine();

                if (playAgain == "n" || playAgain == "N")
                {
                    isAlive = false;
                }
                else
                {
                }
            }
        }        
    }
}

// ***Things to add ***
// Does the player miss a swing?
// Dogleg left/right
// Distance to pin if Dogleg left/right
// Out of bounds if Dogleg left/right
// If player strikes ball to hard from the back of the cup and get Out of bounds behind Tee
// Leaderboard
// More players
// Player custom name
// Player strength, accuracy etc. (randomize?)
// Randomize stroke length?
