using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TestTaskConsoleApp.Constants;
using TestTaskConsoleApp.Models;
using TestTaskConsoleApp.Services;
using Xunit;

namespace TestTaskConsoleApp.Tests.Services
{
    public class BookServiceTests
    {
        [Fact]
        public async Task ExtractBooksData_CorrectApiAddress_ReturnsDeserializedModel()
        {
            // Arrange & Act
            var result = await BookService.ExtractBooksData(Urls.Api);

            // Assert
            Assert.IsType<BooksJsonModel>(result);
        }

        [Fact]
        public void FilterBooksByStatesAndParent_ReturnsFilteredBooks()
        {
            // Arrange
            var allBooks = new List<Book>
            {
                new Book
                {
                    Id = 1,
                    DisplayName = "Book 1",
                    Meta = new Meta
                    {
                        States = new [] { USAStates.Colorado }
                    },
                    ParentName = "Parent 1"
                },
                new Book
                {
                    Id = 2,
                    DisplayName = "Book 2",
                    Meta = new Meta
                    {
                        States = new [] { USAStates.NewJersey }
                    },
                    ParentName = "Parent 2"
                },
                new Book
                {
                    Id = 3,
                    DisplayName = "Book 3",
                    Meta = new Meta
                    {
                        States = new [] { USAStates.NewYork }
                    },
                    ParentName = "Parent 3"
                }
            };

            // Act
            var filteredBooks = BookService.FilterBooksByStatesAndParent(allBooks);

            // Assert
            Assert.Equal(2, filteredBooks.Count);
            Assert.Contains(filteredBooks, book => book.Id == 1);
            Assert.Contains(filteredBooks, book => book.Id == 2);
        }

        [Fact]
        public void GroupAndOrderBooksByParentName_ReturnsCorrectGroups()
        {
            // Arrange
            var books = new List<Book>
            {
                new Book { Id = 1, ParentName = "Parent 2" },
                new Book { Id = 2, ParentName = "Parent 1" },
                new Book { Id = 3, ParentName = "Parent 3" },
                new Book { Id = 4, ParentName = "Parent 2" },
                new Book { Id = 5, ParentName = "Parent 3" },
                new Book { Id = 6, ParentName = "Parent 1" }
            };

            var expectedGroupedBooks = new Dictionary<string, List<Book>>
            {
                { "Parent 1", new List<Book> { books[1], books[5] } },
                { "Parent 2", new List<Book> { books[0], books[3] } },
                { "Parent 3", new List<Book> { books[2], books[4] } }
            };

            // Act
            var groupedBooks = BookService.GroupAndOrderBooksByParentName(books);

            // Assert
            Assert.Equal(expectedGroupedBooks.Count, groupedBooks.Count());

            foreach (var expectedGroup in expectedGroupedBooks)
            {
                var actualGroup = groupedBooks.FirstOrDefault(group => group.Key == expectedGroup.Key);
                Assert.NotNull(actualGroup);
                Assert.Equal(expectedGroup.Value, actualGroup.ToList());
            }
        }

        [Fact]
        public async Task SaveGroupedBooksToFile_WritesCorrectDataToFile()
        {
            // Arrange
            var books = new List<Book>
            {
                new Book { DisplayName = "Book 1", Meta = new Meta { States = new[] { "CO", "NJ" } }, ParentName = "Parent 1" },
                new Book { DisplayName = "Book 2", Meta = new Meta { States = new[] { "CO" } }, ParentName = "Parent 2" },
                new Book { DisplayName = "Book 3", Meta = new Meta { States = new[] { "NJ" } }, ParentName = "Parent 1" }
            };

            var groupedBooks = books
                .GroupBy(b => b.ParentName);

            var tempFilePath = Path.GetTempFileName();
            try
            {
                // Act
                await BookService.SaveGroupedBooksToFile(groupedBooks, tempFilePath);

                // Assert
                var expectedContent = $"Parent 1{Environment.NewLine}" +
                                      $"Book 1 CO, NJ{Environment.NewLine}" +
                                      $"Book 3 NJ{Environment.NewLine}" +
                                      $"Parent 2{Environment.NewLine}" +
                                      $"Book 2 CO";
                var actualContent = File.ReadAllText(tempFilePath);
                Assert.Equal(expectedContent, actualContent.Trim());
            }
            finally
            {
                File.Delete(tempFilePath);
            }
        }
    }
}