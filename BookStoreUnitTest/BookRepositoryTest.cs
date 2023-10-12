using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookRepository;
using System.Linq;
using BookStore;

namespace BookRepositoryTests
{
    [TestClass]
    public class BooksRepositoryTests
    {
        [TestMethod]
        public void AddBook_ShouldIncreaseBookCount()
        {
            var repository = new BooksRepository();
            var initialCount = repository.Get().Count;

            repository.Add(new Book { Title = "New Book", Price = 50});

            var books = repository.Get();
            Assert.AreEqual(initialCount + 1, books.Count);
            Assert.IsTrue(books.Any(b => b.Title == "New Book"));
        }

        [TestMethod]
        public void DeleteBook_ShouldDecreaseBookCount()
        {
            var repository = new BooksRepository();
            var bookToDelete = repository.Get().First();
            var initialCount = repository.Get().Count;

            repository.Delete(bookToDelete.Id);

            var books = repository.Get();
            Assert.AreEqual(initialCount - 1, books.Count);
            Assert.IsFalse(books.Any(b => b.Id == bookToDelete.Id));
        }

        [TestMethod]
        public void UpdateBook_ShouldModifyBookData()
        {
            var repository = new BooksRepository();
            var bookToUpdate = repository.Get().First();
            var updatedBook = new Book { Title = "Updated Book", Price = 60};

            repository.Update(bookToUpdate.Id, updatedBook);

            var updated = repository.Get().First(b => b.Id == bookToUpdate.Id);
            Assert.AreEqual(updatedBook.Title, updated.Title);
            Assert.AreEqual(updatedBook.Price, updated.Price);
        }
    }
}
