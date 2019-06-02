using NonDBStore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NonDBStore.Payload
{
    public static class AuthorPayload
    {
        #region Create
        public static Author Add(Author newAuthor)
        {
            GlobalStore.GLobalStorage.Authors.TryAdd(newAuthor.Id, newAuthor);
            return newAuthor;
        }
        #endregion
        
        #region Read
        public static List<Author> Get()
        {
            List<Author> _author = new List<Author>();
            foreach(var item in GlobalStore.GLobalStorage.Authors)
            {
                _author.Add(item.Value);
            }
            
            return _author;
        }
        public static List<Author> GetById(string Id)
        {
            List<Author> _author = new List<Author>();
            foreach (var item in GlobalStore.GLobalStorage.Authors)
            {
                if(item.Key == Id)
                {
                    _author.Add(item.Value);
                    break;
                }                
            }

            return _author;
        }
        #endregion

        #region Update
        public static object Update(Author updatedAuthor)
        {
            bool result = false;
            foreach (var a in GlobalStore.GLobalStorage.Authors)
            {
                if (a.Key == updatedAuthor.Id)
                {
                    result = GlobalStore.GLobalStorage.Authors.TryUpdate(updatedAuthor.Id, updatedAuthor, a.Value);
                }
            }
            if (result) return updatedAuthor;
            else return new { error = "Author cannot be updated" };
        }
        #endregion

        #region delete
        public static object Delete(string Id)
        {
            bool result = false;
            Author deletedAuthor = new Author();
            foreach (var a in GlobalStore.GLobalStorage.Authors)
            {
                if (a.Key == Id)
                {
                    deletedAuthor = a.Value;
                    result = GlobalStore.GLobalStorage.Authors.TryRemove(Id, out deletedAuthor);
                }
            }
            if (result) return deletedAuthor;
            else return new { error = "Author cannot be deleted" };
        }
        #endregion
    }
}
