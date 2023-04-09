﻿using BookStorage.Application.Commands.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStorage.Application.Commands.BookCommands
{
    public class InsertBookCommand : ICommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public DateTime PublishDate { get; set; }
        public string Genre { get; set; }
    }
}
