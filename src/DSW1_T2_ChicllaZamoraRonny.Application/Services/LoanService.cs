using AutoMapper;
using DSW1_T2_ChicllaZamoraRonny.Application.DTOs;
using DSW1_T2_ChicllaZamoraRonny.Application.Interfaces;
using DSW1_T2_ChicllaZamoraRonny.Domain.Entities;
using DSW1_T2_ChicllaZamoraRonny.Domain.Ports.Out;

namespace DSW1_T2_ChicllaZamoraRonny.Application.Services
{
    public class LoanService : ILoanService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LoanService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LoanDto>> GetActiveLoansAsync()
        {
            var loans = await _unitOfWork.Loans.GetActiveLoansAsync();
            return _mapper.Map<IEnumerable<LoanDto>>(loans);
        }

        public async Task<LoanDto> CreateLoanAsync(CreateLoanDto dto)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(dto.BookId);
            if (book == null) throw new Exception("Libro no encontrado.");
            if (book.Stock <= 0) throw new Exception("Sin stock disponible.");

            book.Stock--;
            _unitOfWork.Books.Update(book);

            var loan = _mapper.Map<Loan>(dto);
            loan.Status = "Active";
            
            await _unitOfWork.Loans.AddAsync(loan);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<LoanDto>(loan);
        }

        public async Task ReturnLoanAsync(int loanId)
        {
            var loan = await _unitOfWork.Loans.GetByIdAsync(loanId);
            if (loan == null || loan.Status == "Returned") throw new Exception("Préstamo inválido.");

            var book = await _unitOfWork.Books.GetByIdAsync(loan.BookId);
            if(book != null) 
            {
                book.Stock++;
                _unitOfWork.Books.Update(book);
            }

            loan.Status = "Returned";
            loan.ReturnDate = DateTime.Now;
            _unitOfWork.Loans.Update(loan);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}