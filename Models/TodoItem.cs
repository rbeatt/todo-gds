using System.ComponentModel.DataAnnotations;

namespace TodoGDS;

public class TodoItem
{
    [Required(ErrorMessage = "Id is required")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Description is required")]
    [StringLength(50, ErrorMessage = "Description cannot be longer than 50 characters")]
    public string Description { get; set; } = String.Empty;

    [Required(ErrorMessage = "IsCompleted is required")]
    public bool IsCompleted { get; set; } = false;
}
