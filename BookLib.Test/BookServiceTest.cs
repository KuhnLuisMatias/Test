using BookLib.Model;
using BookLib.Repositories;
using BookLib.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace BookLib.Test
{
    [TestClass]
    public class BookServiceTest
    {
        private BookService _bookService;
        private Book _newBook;
        private Book _expectedBook;
        private Mock<IBookRepository> _serviceMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _newBook = new Book()
            {
                Id = 0,
                Publisher = "Gabriel García Márquez",
                Title = "Cien años de soledad"
            };

            _expectedBook = new Book()
            {
                Id = 1,
                Publisher = "Miguel de Cervantes",
                Title = "Don Quijote de la Mancha"
            };

            #region Setup
            _serviceMock = new Mock<IBookRepository>();
            _serviceMock.Setup(service => service.Create(_newBook)).ReturnsAsync(_expectedBook);
            _serviceMock.Setup(service => service.GetBookByID(_newBook.Id)).Returns(_newBook);
            _serviceMock.Setup(service => service.Update(_newBook)).Returns(true);
            _serviceMock.Setup(service => service.Delete(_newBook)).Returns(true);
            _serviceMock.Setup(service => service.Read()).Returns(new List<Book>() { _newBook, _expectedBook });
            _bookService = new BookService(_serviceMock.Object);
            #endregion
        }


        [TestMethod]
        public void CreateBook_MustReturn_ExpectedBook()
        {
            var bookExpected = _bookService.Create(_newBook);
            Assert.AreEqual(_expectedBook, bookExpected.Result);
        }

        [TestMethod]
        public void ReadBooks_MustReturn_ListOfBooks()
        {
            var books = _bookService.Read();
            Assert.IsNotNull(books);
            Assert.IsTrue(books.Count() > 0);
        }

        [TestMethod]
        public void UpdateBook_MustReturn_ExpectedBook()
        {
            var value = _bookService.Update(_newBook);
            Assert.AreEqual(value, true, "UpdateBook");
        }

        [TestMethod]
        public void DeleteBook_MustReturn_True()
        {
            var value = _bookService.Delete(_newBook);
            Assert.AreEqual(value, true, "RemoveBook");
        }
    }
}
