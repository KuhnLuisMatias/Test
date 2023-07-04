using BookLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib.Repositories
{
    public interface IBookRepository
    {
        Task<Book> Create(Book item);
        IEnumerable<Book> Read();
        bool Update(Book item);
        bool Delete(Book item);
        Book GetBookByID(int id);
    }
}
