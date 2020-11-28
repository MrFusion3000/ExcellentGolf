using System;
using System.Collections.Generic;

namespace ExcellentGolf
{
    class Program
    {
        static void Main()
        {
            bool isAlive = true;
            while (isAlive)
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
                
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=================================================================");
                Console.WriteLine("{0} is about to play his most important hole, ever.\n", player.Name);
                Console.WriteLine("Course length: {0}", course.CourseLength);
                Console.WriteLine("Distance to Pin: {0}", DistanceToPin.ToString("0.##"));
                Console.WriteLine("=================================================================\n");
                Console.ForegroundColor = ConsoleColor.Gray;


                double ShotAngle;
                double ShotSpeed;
                double ShotLength;
                string ContinueMessage ="Continue?";

                List<LogEntry> newLog = new List<LogEntry>();

                bool inPlay = true;
                while (inPlay)
                {
                    ShotAngle = Ball.CalcAngleInDegrees();
                    ShotSpeed = Ball.CalcVelocity();
                    ShotLength = ball.BallHit(ShotSpeed, ShotAngle);
                    player.Strokes++;

                    LogEntry logEntry = new LogEntry(player.Name, player.Strokes, ShotLength);
                    newLog.Add ( logEntry );

                    Console.WriteLine("Shot length: {0}", ShotLength.ToString("0.##"));

                    try
                    {
                        // Check if ball is between cup and end of course
                        if (ball.PlacementOfBall > course.CourseLength - course.PlacementOfPin && ball.PlacementOfBall < course.CourseLength)
                        {
                            // Yes - reverse shot
                            ShotLength *= -1;
                        }
                        else
                        {
                            // No - normal shot
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
                            if (ball.PlacementOfBall >= (course.CourseLength - course.PlacementOfPin) - 1 && ball.PlacementOfBall <= (course.CourseLength - course.PlacementOfPin) + 1)
                            {
                                Console.WriteLine("YES!");
                                throw new WinException("It's in the hole!");
                            }
                            // Ball infront of pin
                            if (ball.PlacementOfBall < course.CourseLength - course.PlacementOfPin)
                            {
                                Console.WriteLine("Distance to pin: {0} meters.", (DistanceToPin).ToString("0.##"));
                            }
                            // Ball between pin and end of course?
                            else if (ball.PlacementOfBall > course.CourseLength - course.PlacementOfPin && ball.PlacementOfBall < course.CourseLength)
                            {                            
                                Console.WriteLine("Distance to pin: {0} meters.", (DistanceToPin *= -1).ToString("0.##"));
                            }
                            ContinueMessage = "Next stroke?";
                        }
                        else
                        {
                            //ball.PlacementOfBall = 0.0;
                            //You loose!
                            throw new CustomException("Ball Out Of Bounds!");
                        }                
                    }            
                    catch (CustomException ex)
                    {
                        // Handle exception Out Of Bounds
                        ball.PlacementOfBall = 0.0;
                        Console.WriteLine("You loose!");
                        Console.WriteLine("Error 1: {0}", ex.Message);
                        ContinueMessage = "Play again?";
                        inPlay = false;
                    }
                    catch (WinException ex)
                    {
                        // Handle Exception If Ball in Cup
                        Console.WriteLine(ex.Message);
                        ContinueMessage = "Play Again?";
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
                        inPlay = false;
                        ContinueMessage = "Play again?";
                        Console.WriteLine("Error 2: {0}", ex.Message);
                    }

                    Console.WriteLine(ContinueMessage);
                    string playAgain = Console.ReadLine();

                    if (ContinueMessage == "Play again?" && playAgain == "n" || ContinueMessage == "Play again?" && playAgain == "N")
                    {
                        inPlay = false;
                        isAlive = false;
                    }
                    else if (ContinueMessage == "Next stroke?" && playAgain == "n" || ContinueMessage == "Next stroke?" && playAgain == "N")
                    {
                        inPlay = false;
                        Console.WriteLine("You didn't finsish, wanna play a new game?");
                        playAgain = Console.ReadLine();
                        
                        if (playAgain == "n" || ContinueMessage == "Next stroke?" && playAgain == "N")
                        {
                            isAlive = false;
                        }
                    }
                    else
                    {

                    }
                }
                
                // Print Log
                LogEntry.PrintLog(newLog);
            }
        }
    }
}

// ***Ideas to add ***
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
