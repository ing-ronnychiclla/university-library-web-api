namespace DSW1_T2_ChicllaZamoraRonny.Application.DTOs
{
    public record CreateLoanDto(int BookId, string StudentName);
    public record LoanDto(int Id, int BookId, string BookTitle, string StudentName, DateTime LoanDate, string Status);
}