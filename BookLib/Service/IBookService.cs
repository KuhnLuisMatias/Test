using BookLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib.Service
{
    public interface IBookService
    {
        Task<Book> Create(Book book);
        IEnumerable<Book> Read();
        bool Update(Book book);
        bool Delete(Book book);
    }
}
