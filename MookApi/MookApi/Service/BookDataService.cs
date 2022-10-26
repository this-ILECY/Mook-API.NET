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
                    books.isDeleted = false;
                    books.author = bookViewModel.author;
                    books.publisher = bookViewModel.publisher;
                    books.bookPagesCount = bookViewModel.bookPagesCount;
                    books.bookRating = bookViewModel.bookRating;
                    books.bookName = bookViewModel.bookName;
                    books.bookRatingCount = bookViewModel.bookRatingCount;
                    books.bookDescription = bookViewModel.bookDescription;
                    books.isAvailable = bookViewModel.isAvailable;
                    books.isDamaged = bookViewModel.isDamaged;


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
                    .FirstOrDefault(x => x.bookName.Replace(" ", "") == bookViewModel.bookName.Replace(" ", "") 
                    & x.publisher.Replace(" ", "") == bookViewModel.publisher.Replace(" ", "")
                    & x.bookPagesCount == bookViewModel.bookPagesCount
                    & x.author.Replace(" ","") == bookViewModel.author.Replace(" ",""));

                if (nameIsSimilar != null) return false;

                books.isDeleted = false;
                books.author = bookViewModel.author;
                books.publisher = bookViewModel.publisher;
                books.bookPagesCount = bookViewModel.bookPagesCount;
                books.bookRating = 0;
                books.bookName = bookViewModel.bookName;
                books.bookRatingCount = 0;
                books.bookDescription = bookViewModel.bookDescription;
                books.isAvailable = false;
                books.isDamaged = false;
                books.createdDate = bookViewModel.createdDate;
                books.updateDate = bookViewModel.createdDate;
                books.acceptedAdminID = bookViewModel.acceptedAdminID;

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
