using System.ComponentModel.DataAnnotations;

namespace BookStore.Models;

public class User
{
    public int Id { get; set; }
    [Required(ErrorMessage = "The name is mandatory bro")]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "The email is mandatory bro")]
    [EmailAddress(ErrorMessage = "Insert the format for emails, dumb.")]
    public string Email { get; set; } = string.Empty;
}