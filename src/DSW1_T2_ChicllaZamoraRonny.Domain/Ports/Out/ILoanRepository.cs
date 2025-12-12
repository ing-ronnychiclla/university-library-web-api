using DSW1_T2_ChicllaZamoraRonny.Domain.Entities;

namespace DSW1_T2_ChicllaZamoraRonny.Domain.Ports.Out
{
    public interface ILoanRepository : IRepository<Loan>
{
    Task<IEnumerable<Loan>> GetActiveLoansAsync();
}
}