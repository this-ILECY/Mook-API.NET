using AutoMapper;
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
                author = c.Author,
                bookDescription = c.BookDescription,
                bookID = c.BookID,
                bookName = c.BookName,
                bookPagesCount = c.BookPagesCount,
                bookRating = c.BookRating,
                bookRatingCount = c.BookRatingCount,
                isAvailable = c.IsAvailable,
                isDamaged = c.IsDamaged,
                publisher = c.publisher
            }).ToList();

            return books;
        }

        public BookViewModel getByID(int bookID)
        {
            var bookConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RequestHeader, StudentReportViewModel>();
                cfg.CreateMap<RequestDetails, RequestDetailViewModel>();
                cfg.CreateMap<Books, BookViewModel>();
                cfg.CreateMap<Students, StudentViewModel>();
            });

            IMapper mapper = bookConfig.CreateMapper();

            Books books = new Books();
            books = _context.Books.Where(x=> x.BookID == bookID).FirstOrDefault();

            BookViewModel bookViewModel = new BookViewModel();
            bookViewModel = mapper.Map<BookViewModel>(books);

            return bookViewModel;
        }

        public Boolean Update(BookViewModel bookViewModel)
        {
            try
            {
                Books books = new Books();
                books = _context.Books.Where(c => c.BookID == bookViewModel.bookID).FirstOrDefault();

                if (books != null)
                {
                    books.IsDeleted = false;
                    books.Author = bookViewModel.author;
                    books.publisher = bookViewModel.publisher;
                    books.BookPagesCount = bookViewModel.bookPagesCount;
                    books.BookRating = bookViewModel.bookRating;
                    books.BookName = bookViewModel.bookName;
                    books.BookRatingCount = bookViewModel.bookRatingCount;
                    books.BookDescription = bookViewModel.bookDescription;
                    books.IsAvailable = bookViewModel.isAvailable;
                    books.IsDamaged = bookViewModel.isDamaged;


                    _context.Books.Update(books);
                    _context.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        
    }
}
