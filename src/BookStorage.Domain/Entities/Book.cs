using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStorage.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public DateTime PublishDate { get; set; }
        public string Genre { get; set; }
        public virtual Author Author { get; set; }
    }
}