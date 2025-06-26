using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.ViewModel
{
    public class BookEditViewModel
    {
        [Required, MaxLength(255)]
        public string Title { get; set; }
        [Required, MaxLength(100)]
        public string Author { get; set; }
        [MaxLength(50)]
        public string Genre { get; set; }
        [Range(1, int.MaxValue)]
        public int TotalQuantity { get; set; }
    }
}
