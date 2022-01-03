using System.Runtime.Serialization;

namespace FizzBuzzService.Exceptions
{
    public class LimitLessThanStartingNumberException : Exception
    {
        private static string errorMessage = "Limit Number cannot be lower than starting number.";
        public LimitLessThanStartingNumberException() : base(errorMessage)
        {
        }

        public LimitLessThanStartingNumberException(string message, Exception inner) : base(errorMessage, inner)
        {
        }

        protected LimitLessThanStartingNumberException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
