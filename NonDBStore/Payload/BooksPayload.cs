using NonDBStore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NonDBStore.Payload
{
    public static class BooksPayload
    {
        #region Create
        public static Book Add(Book newBook)
        {
            GlobalStore.GLobalStorage.Books.TryAdd(newBook.Id, newBook);
            return newBook;
        }
        #endregion
        
        #region Read
        public static List<Book> Get()
        {
            List<Book> _book = new List<Book>();
            foreach(var item in GlobalStore.GLobalStorage.Books)
            {
                _book.Add(item.Value);
            }
            
            return _book;
        }
        public static List<Book> GetById(string Id)
        {
            List<Book> _book = new List<Book>();
            foreach (var item in GlobalStore.GLobalStorage.Books)
            {
                if(item.Key == Id)
                {
                    _book.Add(item.Value);
                    break;
                }                
            }

            return _book;
        }
        #endregion

        #region Update
        public static object Update(Book updatedBook)
        {
            bool result = false;
            foreach (var a in GlobalStore.GLobalStorage.Books)
            {
                if (a.Key == updatedBook.Id)
                {
                    result = GlobalStore.GLobalStorage.Books.TryUpdate(updatedBook.Id, updatedBook, a.Value);
                }
            }
            if (result) return updatedBook;
            else return new { error = "Book cannot be updated" };
        }
        #endregion

        #region delete
        public static object Delete(string Id)
        {
            bool result = false;
            Book deletedBook = new Book();
            foreach (var a in GlobalStore.GLobalStorage.Books)
            {
                if (a.Key == Id)
                {
                    deletedBook = a.Value;
                    result = GlobalStore.GLobalStorage.Books.TryRemove(Id, out deletedBook);
                }
            }
            if (result) return deletedBook;
            else return new { error = "Book cannot be deleted" };
        }
        #endregion
    }
}
