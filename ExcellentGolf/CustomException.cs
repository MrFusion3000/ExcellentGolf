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

            

}
