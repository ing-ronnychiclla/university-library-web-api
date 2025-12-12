namespace DSW1_T2_ChicllaZamoraRonny.Domain.Exceptions
{
    public class OutOfStockException : DomainException
    {
        public OutOfStockException(string bookTitle) 
            : base($"El libro '{bookTitle}' no tiene stock disponible para préstamo.")
        {
        }
    }
}