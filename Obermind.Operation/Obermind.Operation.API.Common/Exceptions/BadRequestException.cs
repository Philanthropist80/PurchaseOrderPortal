using System;

namespace Obermind.Operation.API.Common
{
    public class BadRequestException : Exception
    {

        public BadRequestException(string message) : base("<|>"+message+"<|>")
        {
        }
        public BadRequestException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
