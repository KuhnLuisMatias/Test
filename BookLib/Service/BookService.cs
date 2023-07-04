using BookLib.Model;
using BookLib.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib.Service
{
    public class BookService : IBookService
    {

        private ObservableCollection<Book> _books = new ObservableCollection<Book>();
        private IBookRepository _repository;
        public BookService(IBookRepository repo)
        {
            _repository = repo;
        }
        public IEnumerable<Book> Read()
        {
            if (_books.Count > 0) return _books;

            var books = _repository.Read();
            
            foreach (var b in books)
                _books.Add(b);

            return _books;
        }
        public async Task<Book> Create(Book book)
        {
            Book newBook = null;
            newBook = await _repository.Create(book);
            return newBook;
        }

        public bool Delete(Book book)
        {
            Book bookToDelete = _repository.GetBookByID(book.Id);

            if (bookToDelete != null)
                return _repository.Delete(bookToDelete);

            return false;
        }

        public bool Update(Book book)
        {
            var bookToUpdate = _repository.GetBookByID(book.Id);
            return _repository.Update(book);
        }

      
    }
}
