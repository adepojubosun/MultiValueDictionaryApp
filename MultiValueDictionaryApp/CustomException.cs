using System;
namespace MultiValueDictionaryApp
{
    public class CustomException : Exception
    {

        public CustomException()
        {
        }

        public CustomException(String message) : base(message)
        {
        }

        public CustomException(String message, Exception inner) : base(message, inner)
        {

        }
    }
}
