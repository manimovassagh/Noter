using System.ComponentModel.DataAnnotations;

namespace Noter.Models
{
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }

        [Required]
        public bool IsCompleted { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public string UserId { get; set; } = string.Empty; // GUID of the user

        [Required]
        public string UserName { get; set; } = string.Empty; // User's username
    }
}