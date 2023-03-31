using System;

namespace CarRentalCore.Exceptions
{
    public class BussinessException : Exception
    {
        public BussinessException()
        {

        }

        public BussinessException(string message) : base(message)
        {

        }


    }
}
