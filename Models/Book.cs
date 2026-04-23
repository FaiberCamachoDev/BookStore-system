using System.ComponentModel.DataAnnotations;

namespace BookStore.Models;

public class Book
{
    public int Id { get; set; } // PK

    [Required(ErrorMessage = "The title is mandatory reicon, put it jiji")] 
    public string Title { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "The Author is mandatory reicon, put it jiji")] // requerido
    [StringLength(100, ErrorMessage = "The author cannot superar 100chars")]
    public string Author { get; set; } = string.Empty;
    [Required(ErrorMessage = "The price is mandatory reicon, put it jiji")]
    [Range(10_000,1_000_000, ErrorMessage =  "The price must be between 10.000 and 1'000.000")]
    public double Price { get; set; }  
    public bool IsLoaned { get; set; } = false;
}