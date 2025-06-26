namespace LibraryManagementSystem.ViewModel
{
    public class BorrowViewModel
    {
        public int TransactionID { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
