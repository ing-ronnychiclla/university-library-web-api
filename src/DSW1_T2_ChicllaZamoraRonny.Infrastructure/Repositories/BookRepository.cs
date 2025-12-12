using Microsoft.EntityFrameworkCore;
using DSW1_T2_ChicllaZamoraRonny.Domain.Entities;
using DSW1_T2_ChicllaZamoraRonny.Domain.Ports.Out;
using DSW1_T2_ChicllaZamoraRonny.Infrastructure.Data;

namespace DSW1_T2_ChicllaZamoraRonny.Infrastructure.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context) { }
        public async Task<Book?> GetByIsbnAsync(string isbn) => 
            await _context.Books.FirstOrDefaultAsync(b => b.ISBN == isbn);
    }
}