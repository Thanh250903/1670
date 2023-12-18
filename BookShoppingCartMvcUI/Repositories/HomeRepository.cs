

using Microsoft.EntityFrameworkCore;

namespace BookShoppingCartMvcUI.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext _db;

        public HomeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Category>> Categories()
        {
            return await _db.Categories.ToListAsync();
        }
        public async Task<IEnumerable<Book>> GetBooks(string sTerm = "", int genreId = 0)
        {
            sTerm = sTerm.ToLower();
            IEnumerable<Book> books = await (from book in _db.Books
                         join category in _db.Categories
                         on book.CategoryId equals category.Id
                         where string.IsNullOrWhiteSpace(sTerm) || (book != null && book.Title.ToLower().StartsWith(sTerm))
                         select new Book
                         {
                             Id = book.Id,
                             ImageUrl = book.ImageUrl,
                             Author = book.Author,
                             Title = book.Title,
                             CategoryId = book.CategoryId,
                             Price = book.Price,
                             CategoryName = category.CategoryName
                         }
                         ).ToListAsync();
            if (genreId > 0)
            {

                books = books.Where(a => a.CategoryId == genreId).ToList();
            }
            return books;

        }
    }
}
