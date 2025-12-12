namespace DSW1_T2_ChicllaZamoraRonny.Application.DTOs
{
    public record CreateBookDto(string Title, string Author, string ISBN, int Stock);
    public record BookDto(int Id, string Title, string Author, string ISBN, int Stock);
}