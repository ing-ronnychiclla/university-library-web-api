using DSW1_T2_ChicllaZamoraRonny.Domain.Ports.Out;
using DSW1_T2_ChicllaZamoraRonny.Infrastructure.Data;

namespace DSW1_T2_ChicllaZamoraRonny.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IBookRepository Books { get; }
        public ILoanRepository Loans { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Books = new BookRepository(_context);
            Loans = new LoanRepository(_context);
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();
    }
}