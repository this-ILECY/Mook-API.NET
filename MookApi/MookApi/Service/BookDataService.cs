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

            var bookConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Books, BookViewModel>();
            });
            IMapper mapper = bookConfig.CreateMapper();

            List<Books> books = new List<Books>();
            books = _context.Books.ToList();
            List<BookViewModel> bookviewModels = new List<BookViewModel>();
            bookviewModels = mapper.Map<List<BookViewModel>>(books);

            return bookviewModels;
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
            books = _context.Books.Where(x => x.bookID == bookID).FirstOrDefault();

            BookViewModel bookViewModel = new BookViewModel();
            bookViewModel = mapper.Map<BookViewModel>(books);

            return bookViewModel;
        }

        public Boolean Update(BookViewModel bookViewModel)
        {
            try
            {
                Books books = new Books();
                books = _context.Books.Where(c => c.bookID == bookViewModel.bookID).FirstOrDefault();

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
        public Boolean Create(BookViewModel bookViewModel)
        {
            try
            {
                Books books = new Books();
                Books nameIsSimilar = _context.Books
                    .FirstOrDefault(x => x.BookName.Replace(" ", "") == bookViewModel.bookName.Replace(" ", "") 
                    & x.publisher.Replace(" ", "") == bookViewModel.publisher.Replace(" ", "")
                    & x.BookPagesCount == bookViewModel.bookPagesCount
                    & x.Author.Replace(" ","") == bookViewModel.author.Replace(" ",""));

                if (nameIsSimilar != null) return false;

                books.IsDeleted = false;
                books.Author = bookViewModel.author;
                books.publisher = bookViewModel.publisher;
                books.BookPagesCount = bookViewModel.bookPagesCount;
                books.BookRating = 0;
                books.BookName = bookViewModel.bookName;
                books.BookRatingCount = 0;
                books.BookDescription = bookViewModel.bookDescription;
                books.IsAvailable = false;
                books.IsDamaged = false;
                books.createdDate = bookViewModel.createdDate;
                books.UpdateDate = bookViewModel.createdDate;
                books.AcceptedAdminID = bookViewModel.AcceptedAdminID;

                _context.Books.Add(books);
                _context.SaveChanges();

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
