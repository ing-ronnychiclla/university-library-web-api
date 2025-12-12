using AutoMapper;
using DSW1_T2_ChicllaZamoraRonny.Application.DTOs;
using DSW1_T2_ChicllaZamoraRonny.Application.Interfaces;
using DSW1_T2_ChicllaZamoraRonny.Domain.Entities;
using DSW1_T2_ChicllaZamoraRonny.Domain.Ports.Out;

namespace DSW1_T2_ChicllaZamoraRonny.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            var books = await _unitOfWork.Books.GetAllAsync();
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<BookDto> CreateBookAsync(CreateBookDto dto)
        {
            var existing = await _unitOfWork.Books.GetByIsbnAsync(dto.ISBN);
            if (existing != null) throw new Exception("El ISBN ya existe.");

            var book = _mapper.Map<Book>(dto);
            await _unitOfWork.Books.AddAsync(book);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<BookDto>(book);
        }
    }
}