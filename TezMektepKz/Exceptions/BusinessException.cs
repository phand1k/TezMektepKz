namespace TezMektepKz.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message, Exception? inner = null) : base(message, inner) { }
    }
}
