using System;

namespace MinhaPrimeiraApi.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException()
        {
            
        }
        public CustomException(string message) : base(message)
        {
            
        }
    }
}