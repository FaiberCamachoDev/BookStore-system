namespace BookStore.Models;

public class Book
{
    public int Id { get; set; } // PK

    public string Title { get; set; } = string.Empty;

    public string Author { get; set; } = string.Empty;

    public double? Price { get; set; }
}