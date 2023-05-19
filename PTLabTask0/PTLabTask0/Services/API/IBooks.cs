﻿using DataLayer.Implementation;
using System;
namespace Services.API
{
	public interface IBook
	{
        public string Title { get; set; }
        public string Author { get; set; }
        public string BookId { get; set; }
        public string Publisher { get; set; }
        public string Category { get; set; }
        public bool Available { get; set; }

        Task AddAsync();
        Task DeleteAsync();

    }
}
