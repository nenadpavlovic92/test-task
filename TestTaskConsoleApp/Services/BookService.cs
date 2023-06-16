using Newtonsoft.Json;
using TestTaskConsoleApp.Constants;
using TestTaskConsoleApp.Models;

namespace TestTaskConsoleApp.Services
{
    /// <summary>
    /// Service class for operating with books.
    /// </summary>
    public static class BookService
    {
        /// <summary>
        /// Extracts books data from external public API.
        /// </summary>
        /// <returns>The extracted books data.</returns>
        public static async Task<BooksJsonModel> ExtractBooksData(string api)
        {
            using var httpClient = new HttpClient();

            HttpResponseMessage response = await httpClient.GetAsync(api);
                
            if(response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                BooksJsonModel? deserializedModel = JsonConvert.DeserializeObject<BooksJsonModel>(json);

                return deserializedModel ?? throw new JsonSerializationException("Failed to deserialize BooksJsonModel.");
            }
            else
            {
                throw new HttpRequestException("Failed to retrieve books data.");
            }
        }

        /// <summary>
        /// Filters list of books based on criteria.
        /// </summary>
        /// <param name="books">The list of books to filter.</param>
        /// <returns>The filtered list of books.</returns>
        public static List<Book> FilterBooksByStatesAndParent(List<Book> allBooks)
        {
            return allBooks
                .Where(book => (book.Meta?.States?.Contains(USAStates.Colorado) == true || book.Meta?.States?.Contains(USAStates.NewJersey) == true) && book.ParentName != null)
                .ToList();
        }

        /// <summary>
        /// Groups and order by of books based on criteria.
        /// </summary>
        /// <param name="books">The list of books to group and order by.</param>
        /// <returns>The grouped books.</returns>
        public static IEnumerable<IGrouping<string, Book>> GroupAndOrderBooksByParentName(List<Book> filteredBooks)
        {
            return filteredBooks
                .GroupBy(book => book.ParentName!)
                .OrderBy(group => group.Key);
        }

        /// <summary>
        /// Saves grouped books to file.
        /// </summary>
        /// <param name="groupedBooks">The grouped books to save.</param>
        /// <param name="filePath">The path of file.</param>
        /// <returns>Task which is saving grouped books in file.</returns>
        public static async Task SaveGroupedBooksToFile(IEnumerable<IGrouping<string, Book>> groupedBooks, string filePath)
        {
            using var writer = new StreamWriter(filePath);

            foreach (var group in groupedBooks)
            {
                await writer.WriteLineAsync(group.Key);

                foreach (var book in group)
                {
                    string displayName = book.DisplayName ?? string.Empty;
                    string states = book.Meta?.States != null ? string.Join(", ", book.Meta.States) : string.Empty;

                    await writer.WriteLineAsync($"{displayName} {states}");
                }
            }
        }
    }
}
