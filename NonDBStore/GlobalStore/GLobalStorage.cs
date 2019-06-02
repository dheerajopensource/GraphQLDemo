using NonDBStore.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace NonDBStore.GlobalStore
{
    public static class GLobalStorage
    {
        public static ConcurrentDictionary<string, Author> Authors { get; set; }
        public static ConcurrentDictionary<string, Book> Books { get; set; }

        static GLobalStorage()
        {
            Authors = new ConcurrentDictionary<string, Author>();
            Books = new ConcurrentDictionary<string, Book>();
        }
    }
}
