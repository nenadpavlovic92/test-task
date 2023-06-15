using Newtonsoft.Json;

namespace TestTaskConsoleApp.Models
{
    /// <summary>
    /// Represents a JSON model of book.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Gets or sets the id of the book.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the display name of the book.
        /// </summary>
        [JsonProperty("display_name")]
        public string? DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the abbrevation of the book.
        /// </summary>
        [JsonProperty("abbr")]
        public string? Abbr { get; set; }

        /// <summary>
        /// Gets or sets the meta data of the book.
        /// </summary>
        /// <seealso cref="Meta"/>
        [JsonProperty("meta")]
        public Meta? Meta { get; set; }

        /// <summary>
        /// Gets or sets the parent name of the book.
        /// </summary>
        [JsonProperty("parent_name")]
        public string? ParentName { get; set; }

        /// <summary>
        /// Gets or sets the parent id of the book.
        /// </summary>
        [JsonProperty("book_parent_id")]
        public int? BookParentId { get; set; }

        /// <summary>
        /// Gets or sets the affiliate id of the book.
        /// </summary>
        [JsonProperty("affiliate_id")]
        public int? AffiliateId { get; set; }
    }
}
