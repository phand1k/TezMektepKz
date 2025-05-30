namespace TezMektepKz.Exceptions
{
    public class DataAccessException : Exception
    {
        public DataAccessException(string message, Exception? inner = null) : base(message, inner) { }
    }
}
