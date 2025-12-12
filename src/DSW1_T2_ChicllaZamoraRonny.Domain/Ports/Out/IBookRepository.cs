using DSW1_T2_ChicllaZamoraRonny.Domain.Entities;

namespace DSW1_T2_ChicllaZamoraRonny.Domain.Ports.Out
{
    public interface IBookRepository : IRepository<Book>
{
    Task<Book?> GetByIsbnAsync(string isbn);
}
}