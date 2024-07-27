﻿namespace PlaywrightUiTests.ApiTesting.Models
{
    public class User
    {
        public string UserID { get; set; }

        public string Username { get; set; }

        public List<Book> Books { get; set; }

        public User()
        {
            Books = new List<Book>();
        }
    }

    public class Book
    {
        public string? Isbn { get; set; }

        public string? Title { get; set; }

        public string? SubTitle { get; set; }

        public string? Author { get; set; }

        public DateTime PublishDate { get; set; }

        public string? Publisher { get; set; }

        public int Pages { get; set; }

        public string? Description { get; set; }

        public string? Website { get; set; }
    }
}
