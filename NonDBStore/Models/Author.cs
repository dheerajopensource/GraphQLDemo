using System;
using System.Collections.Generic;
using System.Text;

namespace NonDBStore.Models
{
    public class Author
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public List<Book> Books{get;set;} 
    }

    public class AuthorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
