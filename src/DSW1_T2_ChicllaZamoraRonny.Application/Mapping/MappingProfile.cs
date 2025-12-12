using AutoMapper;
using DSW1_T2_ChicllaZamoraRonny.Domain.Entities;
using DSW1_T2_ChicllaZamoraRonny.Application.DTOs;

namespace DSW1_T2_ChicllaZamoraRonny.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookDto, Book>();
            CreateMap<Book, BookDto>();
            CreateMap<CreateLoanDto, Loan>();
            CreateMap<Loan, LoanDto>()
                .ForMember(d => d.BookTitle, o => o.MapFrom(s => s.Book != null ? s.Book.Title : ""));
        }
    }
}