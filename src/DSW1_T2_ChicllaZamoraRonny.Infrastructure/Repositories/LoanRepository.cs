using Microsoft.EntityFrameworkCore;
using DSW1_T2_ChicllaZamoraRonny.Domain.Entities;
using DSW1_T2_ChicllaZamoraRonny.Domain.Ports.Out;
using DSW1_T2_ChicllaZamoraRonny.Infrastructure.Data;

namespace DSW1_T2_ChicllaZamoraRonny.Infrastructure.Repositories
{
    public class LoanRepository : Repository<Loan>, ILoanRepository
    {
        public LoanRepository(ApplicationDbContext context) : base(context) { }
        public async Task<IEnumerable<Loan>> GetActiveLoansAsync() => 
            await _context.Loans.Include(l => l.Book)
                          .Where(l => l.Status == "Active").ToListAsync();
    }
}