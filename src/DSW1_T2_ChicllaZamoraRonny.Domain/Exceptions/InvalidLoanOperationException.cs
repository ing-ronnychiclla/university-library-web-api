namespace DSW1_T2_ChicllaZamoraRonny.Domain.Exceptions
{
    public class InvalidLoanOperationException : DomainException
    {
        public InvalidLoanOperationException(string message) : base(message)
        {
        }
    }
}