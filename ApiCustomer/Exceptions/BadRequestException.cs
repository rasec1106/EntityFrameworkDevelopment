namespace ApiCustomer.Exceptions
{
    public class BadRequestException : Exception
    {
        // This in java is like calling the parent's constructor --> super(message) 
        public BadRequestException(string message) : base(message) { }
    }
}
