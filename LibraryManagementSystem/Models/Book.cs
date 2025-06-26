using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Title { get; set; }

        [Required, MaxLength(100)]
        public string Author { get; set; }

        [MaxLength(50)]
        public string Genre { get; set; }

        [Range(1, int.MaxValue)]
        public int TotalQuantity { get; set; }

        [Range(0, int.MaxValue)]
        public int AvailableQuantity { get; set; }

        public ICollection<BorrowTransaction> BorrowTransactions { get; set; }
    }
}
