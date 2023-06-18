using Newtonsoft.Json;

namespace TestTaskConsoleApp.Models
{
    /// <summary>
    /// Represents a root JSON model of books object.
    /// </summary>
    public class BooksRootModel
    {
        /// <summary>
        /// Get or sets the list of books.
        /// </summary>
        /// <seealso cref="Book"/>
        [JsonProperty("books")]
        public List<Book>? Books { get; set; }
    }
}
