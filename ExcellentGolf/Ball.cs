using System;
using System.Collections.Generic;
using System.Text;

namespace ExcellentGolf
{
    class Ball
    {
        public double PlacementOfBall { get; set; }
        public double Velocity { get; set; }
        public double AngleInDegrees { get; set; }
        public double AngleInRadians { get; set; }

        public Ball()
        { }

        public Ball(double _placementOfBall)
        {
            PlacementOfBall = _placementOfBall;
        }

        //public double CalcBallVerticalPlacement(int leftSide, int rightSide)
        //{
        //    double NewBallVerticalPlacement = 0;
        //    Random rndVertical = new Random();

        //    NewBallVerticalPlacement = rndVertical.Next(leftSide, rightSide);

        //    return NewBallVerticalPlacement;
        //}

        public double BallHit(double Velocity, double AngleInDegrees)
        {
            double Gravity = 9.8;
            AngleInRadians = (double) (Math.PI / 180) * AngleInDegrees;
            double NewBallPlacement = (double)Math.Pow((double)Velocity, 2) / Gravity * Math.Sin((double)(2 * AngleInRadians));

            return NewBallPlacement;
        }

        // Method with 'error handling' using Exceptions
        public static double CalcVelocity()
        {
            
            double Velocity = 0;
            bool isAlive = true;

            while (isAlive)
            {
                Console.WriteLine("Set the velocity (1-100): ");
                
                try
                {
                    bool TestVelocity = double.TryParse(Console.ReadLine(), out Velocity);
                    //TestVelocity = false;

                    switch (TestVelocity)
                    {
                        case true:
                            //throw new Exception("Nice hit!");
                            
                            if (Velocity <= 1 || Velocity >= 100)
                            {
                                Console.WriteLine("Velocity out of bounds! (so to speak!)");
                            }
                            else
                            {
                                isAlive = false;
                            }
                        break;
                        case false:
                            throw new CustomException("Not a valid velocity. Numeric value only!");
                        default:
                    }
                }

                catch (CustomException ex)
                {
                    Console.WriteLine("Input Error: {0}", ex.Message);
                }

                //if (!TestVelocity)
                //{
                //    Console.WriteLine("Not a valid angle!");
                //}
                //else
                //{

                //if (Velocity <= 1 || Velocity >= 100)
                //{
                //    Console.WriteLine("Out of bounds! (so to speak!)");
                //}
                //else
                //{
                //    isAlive = false;
                //}
                //}
            }
            return Velocity;
        }

        // Method with 'error handling' using if-statments
        public static double CalcAngleInDegrees()
        {
            Console.WriteLine("Set the angle (1-89): ");
            double AngleInDegrees = 0;
            bool isAlive = true;

            while (isAlive)
            {
                bool TestAngleInDegrees = double.TryParse(Console.ReadLine(), out AngleInDegrees);

                if (!TestAngleInDegrees)
                {
                    Console.WriteLine("Not a valid angle. Numeric value only!");
                }
                else
                {
                    if (AngleInDegrees <= 1 || AngleInDegrees >= 89)
                    {
                        Console.WriteLine("Degrees out of bounds! (so to speak!)");
                    }
                    else
                    {
                        isAlive = false;
                    }
                }
            }
            return AngleInDegrees;
        }
    }
}
