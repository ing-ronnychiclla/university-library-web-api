using DSW1_T2_ChicllaZamoraRonny.Application.DTOs;

namespace DSW1_T2_ChicllaZamoraRonny.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllBooksAsync();
        Task<BookDto> CreateBookAsync(CreateBookDto dto);
    }
}