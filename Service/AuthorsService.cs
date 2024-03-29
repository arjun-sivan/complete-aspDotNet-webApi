using MyBooks.Data;
using MyBooks.Data.Models;
using MyBooks.Data.ViewModels;

namespace MyBooks.Service
{
    public class AuthorsService
    {

        public AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }


        public void AddAuthor(AuthorVM author)
        {
            var _auhtor = new Author()
            {
                FullName = author.FullName
            };
            _context.Authors.Add(_auhtor);
            _context.SaveChanges();
        }


        public AuthorWithBooksVM GetAuthorWithBooks(int authorId)
        {
            var _author = _context.Authors.Where(n => n.Id == authorId).Select(n => new AuthorWithBooksVM()
            {
                FullName = n.FullName,
                BookTitles = n.Book_Authors.Select(n => n.Book.Title).ToList()
            }).FirstOrDefault();

            return _author;
        }

    }
}
