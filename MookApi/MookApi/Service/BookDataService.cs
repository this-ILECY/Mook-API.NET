using MookApi.Context;
using MookApi.Models;
using MookApi.ViewModel;

namespace MookApi.Service
{
    public class BookDataService
    {
        private readonly AppDbContext _context;

        public BookDataService(AppDbContext context)
        {
            _context = context;
        }

        public List<BookViewModel> get()
        {
            List<BookViewModel> books = new List<BookViewModel>();
            books = _context.Books.Select(c => new BookViewModel()
            {
                Author = c.Author,
                BookDescription = c.BookDescription,
                BookID = c.BookID,
                BookName = c.BookName,
                BookPagesCount = c.BookPagesCount,
                BookRating = c.BookRating,
                BookRatingCount = c.BookRatingCount,
                IsAvailable = c.IsAvailable,
                IsDamaged = c.IsDamaged,
                publisher = c.publisher
            }).ToList();

            return books;
        }

        public BookViewModel getByID(int bookID)
        {
            BookViewModel book = new BookViewModel();
            book = _context.Books.Select(c => new BookViewModel()
            {
                Author = c.Author,
                BookDescription = c.BookDescription,
                BookID = c.BookID,
                BookName = c.BookName,
                BookPagesCount = c.BookPagesCount,
                BookRating = c.BookRating,
                BookRatingCount = c.BookRatingCount,
                IsAvailable = c.IsAvailable,
                IsDamaged = c.IsDamaged,
                publisher = c.publisher
            }).Where(x=> x.BookID == bookID).FirstOrDefault();

            return book;
        }

        
    }
}
