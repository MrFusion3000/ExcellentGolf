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
    }

    class ToManyStrokesException : Exception
    {
        public ToManyStrokesException()
        {

        }

        public ToManyStrokesException(string message) : base(message)
        {

        }
    }

}
