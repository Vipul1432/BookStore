using BookStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Interfaces
{
    public interface IBookRepository
    {
        /// <summary>
        /// Retrieves all books asynchronously.
        /// </summary>
        /// <returns>A collection of books.</returns>
        Task<IEnumerable<Book>> GetAllBooksAsync();
        /// <summary>
        /// Retrieves a book by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The ID of the book to retrieve.</param>
        /// <returns>The book with the specified ID or null if not found.</returns>
        Task<Book> GetBookByIdAsync(int id);
        /// <summary>
        /// Adds a new book asynchronously.
        /// </summary>
        /// <param name="book">The book to add.</param>
        Task AddBookAsync(Book book);
        /// <summary>
        /// Updates an existing book asynchronously.
        /// </summary>
        /// <param name="id">The ID of the book to update.</param>
        /// <param name="updatedBook">The updated book data.</param>
        Task UpdateBookAsync(int id, Book updatedBook);
        /// <summary>
        /// Deletes a book by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The ID of the book to delete.</param>
        Task DeleteBookAsync(int id);
    }
}
