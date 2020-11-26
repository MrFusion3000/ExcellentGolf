using System;
using System.Collections.Generic;
using System.Text;

namespace ExcellentGolf
{
    class CustomException : Exception
    {
        public CustomException()
        {

        }
        public CustomException(string message) : base(message)
        {

        }

        //public CustomException(string message, Ball _ball, double _shotLength) : base(message)
        //{
        //    double ShotLength = _shotLength;
        //    _ball.PlacementOfBall += ShotLength; 
        //}
    }

            

}
