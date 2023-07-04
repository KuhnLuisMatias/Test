using BookLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib.Repositories
{
    public class BookRepository : IBookRepository
    {
        private List<Book> _books;
        public BookRepository()
        {
            Initialize();
        }
        private void Initialize()
        {
            _books = new List<Book>()
            {
                new Book(){Id=0,Publisher="Gabriel García Márquez",Title="Cien años de soledad"},
                new Book(){Id=1,Publisher="Miguel de Cervantes",Title="Don Quijote de la Mancha"},
                new Book(){Id=2,Publisher="El retrato de Dorian Gray",Title="Oscar Wilde"},
            };
        }
        public Task<Book> Create(Book item)
        {
            item.Id = _books.Select(b => b.Id).Max() + 1;
            _books.Add(item);
            return Task.FromResult(item);
        }

        public bool Update(Book item)
        {
            throw new NotImplementedException();
        }

        Book IBookRepository.GetBookByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> Read()
        {
            throw new NotImplementedException();
        }

        public bool Delete(Book item)
        {
            throw new NotImplementedException();
        }
    }
}
