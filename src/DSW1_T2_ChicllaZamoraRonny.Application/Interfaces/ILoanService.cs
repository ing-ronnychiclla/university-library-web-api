using DSW1_T2_ChicllaZamoraRonny.Application.DTOs;

namespace DSW1_T2_ChicllaZamoraRonny.Application.Interfaces
{
    public interface ILoanService
    {
        Task<IEnumerable<LoanDto>> GetActiveLoansAsync();
        Task<LoanDto> CreateLoanAsync(CreateLoanDto dto);
        Task ReturnLoanAsync(int loanId);
    }
}