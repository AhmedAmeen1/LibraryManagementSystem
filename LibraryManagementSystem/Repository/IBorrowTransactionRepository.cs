using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repository;
using LibraryManagementSystem.ViewModel;

namespace LibraryManagementSystem.Repository
{
    public interface IBorrowTransactionRepository : IRepository<BorrowTransaction>
    {
        List<BorrowViewModel> GetBorrowsForUser(string userId);

    }
}
