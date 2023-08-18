using BookStore.Data.Context;
using BookStore.Domain.Interfaces;
using BookStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookstoreDbContext _dbContext;

        public BookRepository(BookstoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Retrieves all books asynchronously.
        /// </summary>
        /// <returns>A collection of all available books.</returns>
        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _dbContext.Books.ToListAsync();
        }

        /// <summary>
        /// Retrieves a book by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The ID of the book to retrieve.</param>
        /// <returns>The book with the specified ID or null if not found.</returns>
        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == id);
        }

        /// <summary>
        /// Adds a new book asynchronously.
        /// </summary>
        /// <param name="book">The book to add.</param>
        public async Task AddBookAsync(Book book)
        {
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing book asynchronously.
        /// </summary>
        /// <param name="id">The ID of the book to update.</param>
        /// <param name="updatedBook">The updated book data.</param>
        /// <exception cref="ArgumentException">Thrown when the specified book ID does not exist.</exception>
        public async Task UpdateBookAsync(int id, Book updatedBook)
        {
            var existingBook = await _dbContext.Books.FindAsync(id);
            if (existingBook != null)
            {
                existingBook.Title = updatedBook.Title;
                existingBook.Author = updatedBook.Author;
                existingBook.Genre = updatedBook.Genre;
                existingBook.Price = updatedBook.Price;
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Book not found.", nameof(id));
            }
        }

        /// <summary>
        /// Deletes a book by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The ID of the book to delete.</param>
        /// <exception cref="ArgumentException">Thrown when the specified book ID does not exist.</exception>
        public async Task DeleteBookAsync(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);
            if (book != null)
            {
                _dbContext.Books.Remove(book);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Book not found.", nameof(id));
            }
        }
    }
}
