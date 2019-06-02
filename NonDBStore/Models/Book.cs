using System;
using System.Collections.Generic;
using System.Text;

namespace NonDBStore.Models
{
    public class Book
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }

        public string AuthorId {get;set;}
    }
}
