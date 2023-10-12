using BookStore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookRepository
{
    public class BooksRepository
    {
        private List<Book> books;

        public BooksRepository()
        {
            books = new List<Book>
            {
                new Book { Id = 1, Title = "Book 1", Price = 20},
                new Book { Id = 2, Title = "Book 2", Price = 15},
                new Book { Id = 3, Title = "Book 3", Price = 25},
                new Book { Id = 4, Title = "Book 4", Price = 30},
                new Book { Id = 5, Title = "Book 5", Price = 18}
            };
        }

        public List<Book> Get()
        {
            return new List<Book>(books);
        }

        public List<Book> Get(double minPrice, double maxPrice)
        {
            return books.Where(book => book.Price >= minPrice && book.Price <= maxPrice).ToList();
        }

        public List<Book> GetSorted(string sortBy)
        {
            if (sortBy.Equals("Title", StringComparison.OrdinalIgnoreCase))
            {
                return books.OrderBy(book => book.Title).ToList();
            }
            else if (sortBy.Equals("Price", StringComparison.OrdinalIgnoreCase))
            {
                return books.OrderBy(book => book.Price).ToList();
            }
            else
            {
                throw new ArgumentException("Invalid sort option.");
            }
        }

        public Book GetById(int id)
        {
            return books.FirstOrDefault(book => book.Id == id);
        }

        public Book Add(Book book)
        {
            int newId = books.Max(b => b.Id) + 1;
            book.Id = newId;
            books.Add(book);
            return book;
        }

        public Book Delete(int id)
        {
            Book bookToRemove = books.FirstOrDefault(book => book.Id == id);
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
            }
            return bookToRemove;
        }

        public Book Update(int id, Book values)
        {
            Book bookToUpdate = books.FirstOrDefault(book => book.Id == id);
            if (bookToUpdate != null)
            {
                bookToUpdate.Title = values.Title;
                bookToUpdate.Price = values.Price;
            }
            return bookToUpdate;
        }
    }
}
