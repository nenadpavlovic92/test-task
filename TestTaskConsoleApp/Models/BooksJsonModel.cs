using Newtonsoft.Json;

namespace TestTaskConsoleApp.Models
{
    /// <summary>
    /// Represents a JSON model of books object.
    /// </summary>
    public class BooksJsonModel
    {
        /// <summary>
        /// Get or sets the list of books.
        /// </summary>
        /// <seealso cref="Book"/>
        [JsonProperty("books")]
        public List<Book>? Books { get; set; }
    }
}
