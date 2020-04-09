using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log;
            log = ReturnMessage;
            
            var result = log("Hello, I'm a delegate.");
            
            Assert.Equal("Hello, I'm a delegate.", result);
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var bookOne = AddBook("Book 1");
            var bookTwo = AddBook("Book 2");

            Assert.Equal("Book 1", bookOne.Name);
            Assert.Equal("Book 2", bookTwo.Name);
            Assert.NotSame(bookOne, bookTwo);
        }

        [Fact]
        public void TwoVariablesCanReferenceSameObject()
        {
            var bookOne = AddBook("Book 1");
            var bookTwo = bookOne;

            Assert.Same(bookOne, bookTwo);
            // Does the same as line above.
            Assert.True(Object.ReferenceEquals(bookOne, bookTwo));
        }

        [Fact]
        public void CanUpdateBookName()
        {
            var book = AddBook("My Book");
            SetBookName(book, "Your Book");

            Assert.Equal("Your Book", book.Name);
            Assert.NotEqual("My Book", book.Name);
        }

        [Fact]
        public void CanPassByValue()
        {
            var book1 = new Book("My Book");
            var book2 = PassByValue(book1);

            Assert.Equal(book1.Name, book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void CanPassByReference()
        {
            // book2 references the object book1 references
            // therefore a change to one object will change another

            var book1 = new Book("My Book");
            var book2 = PassByReference(out book1, "New Name");

            Assert.Equal("New Name", book1.Name);
            Assert.Equal(book1.Name, book2.Name);
            Assert.Same(book1, book2);
        }

        [Fact]
        public void CanSetIntByReference()
        {
            var x = GetInt();
            SetIntByReference(out x);

            Assert.Equal(42, x);
        }

        [Fact]
        public void CannotSetIntByValue()
        {
            var x = 3;
            SetIntByValue(x);

            Assert.Equal(3, x);
        }

        [Fact]
        public void StringBehavesLikeAValue()
        {
            string name = "Name";
            string upperName = MakeUpperCase(name);   

            Assert.Equal("NAME", upperName);
            Assert.NotEqual("NAME", name);
        }

        private string MakeUpperCase(string name)
        {
            return name.ToUpper();
        }

        private void SetIntByValue(int number)
        {
            // this method will not update the value of the passed parameter.

            number = 42;
        }

        private void SetIntByReference(out int number)
        {
            // uses `out` to make sure the parameter number is a reference.
            // without the reference declaration, the number would not be updated.
            // see test `CannotSetIntByValue`.

            number = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        private Book PassByReference(out Book book, string name)
        {
            // `out` is similar to `ref` but forces you to assign
            // the parameter

            return book = new Book(name);
        }

        string ReturnMessage(string message)
        {
            return message;
        }

        private Book PassByValue(Book book)
        {
            return book = new Book(book.Name);
        }

        private void SetBookName(Book book, string name)
        {
            book.Name = name;
        }

        private Book AddBook(string name)
        {
            return new Book(name);
        }
    }
}
