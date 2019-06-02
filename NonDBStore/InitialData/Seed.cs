using NonDBStore.Models;
using NonDBStore.Payload;
using System;
using System.Collections.Generic;
using System.Text;

namespace NonDBStore.InitialData
{
    public static class Seed
    {
        public static IEnumerable<Author> InitAuthors()
        {
            AuthorPayload.Add(new Author() {
                Id = "000-000-001",
                FirstName="Dheeraj",
                LastName = "Kumar",
                Phone = "9999999"
            });
            AuthorPayload.Add(new Author()
            {
                Id = "000-000-002",
                FirstName = "Moni",
                LastName = "Kumar1",
                Phone = "888888"
            });

            var books = InitBooks();

            foreach(var au in AuthorPayload.Get())
            {
                List<Book> booksbyAuthor = new List<Book>();
                foreach(var book in books)
                {
                    if(au.Id == book.AuthorId)
                    {
                        booksbyAuthor.Add(book);
                    }
                }
                au.Books = booksbyAuthor;
            }

            return AuthorPayload.Get();
        }

        public static IEnumerable<Book> InitBooks()
        {
            BooksPayload.Add(new Book()
            {
                Id = "000-000-001",
                AuthorId= "000-000-001",
                Name = "My First Book on .Net",
                Price = 299.00M,
                Type = "Computers"                
            });
            BooksPayload.Add(new Book()
            {
                Id = "000-000-002",
                AuthorId = "000-000-001",
                Name = "My Second Book on .Net Core",
                Price = 499.00M,
                Type = "Computers"
            });

            return BooksPayload.Get();
        }
    }
}
