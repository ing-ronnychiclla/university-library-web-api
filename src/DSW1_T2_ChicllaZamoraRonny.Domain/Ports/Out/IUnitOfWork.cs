namespace DSW1_T2_ChicllaZamoraRonny.Domain.Ports.Out
{
    public interface IUnitOfWork : IDisposable
{
    IBookRepository Books { get; }
    ILoanRepository Loans { get; }
    Task<int> SaveChangesAsync();
}
}