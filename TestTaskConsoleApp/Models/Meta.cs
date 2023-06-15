using Newtonsoft.Json;

namespace TestTaskConsoleApp.Models
{
    /// <summary>
    /// Represents a JSON model of book metadata.
    /// </summary>
    public class Meta
    {
        /// <summary>
        /// Gets or sets the logos of the book.
        /// </summary>
        /// <seealso cref="Logos"/>
        [JsonProperty("logos")]
        public Logos? Logos { get; set; }

        /// <summary>
        /// Gets or sets the states where book is available.
        /// </summary>
        [JsonProperty("states")]
        public string[]? States { get; set; }

        /// <summary>
        /// Gets or sets the website of the book.
        /// </summary>
        [JsonProperty("website")]
        public string? Website { get; set; }

        /// <summary>
        /// Gets or sets the deeplink of the book.
        /// </summary>
        /// <seealso cref="DeepLink"/>
        [JsonProperty("deeplink")]
        public DeepLink? DeepLink { get; set; }

        /// <summary>
        /// Gets or sets if book is legal.
        /// </summary>
        [JsonProperty("is_legal")]
        public bool? IsLegal { get; set; }

        /// <summary>
        /// Gets or sets the betsync type of the book.
        /// </summary>
        [JsonProperty("betsync_type")]
        public int? BetSyncType { get; set; }

        /// <summary>
        /// Gets or sets if the book is prefered.
        /// </summary>
        [JsonProperty("is_preferred")]
        public bool? IsPrefered { get; set; }

        /// <summary>
        /// Gets or sets the primary color of the book.
        /// </summary>
        [JsonProperty("primary_color")]
        public string? PrimaryColor { get; set; }

        /// <summary>
        /// Gets or sets the betsync status of the book.
        /// </summary>
        [JsonProperty("betsync_status")]
        public int? BetSyncStatus { get; set; }

        /// <summary>
        /// Gets or sets the secondary color of the book.
        /// </summary>
        [JsonProperty("secondary_color")]
        public string? SecondaryColor { get; set; }

        /// <summary>
        /// Gets or sets the if the app is fastbet enabled.
        /// </summary>
        [JsonProperty("is_fastbet_enabled_app")]
        public bool? IsFastbetEnabledApp { get; set; }

        /// <summary>
        /// Gets or sets the if the web is fastbet enabled.
        /// </summary>
        [JsonProperty("is_fastbet_enabled_web")]
        public bool? IsFastbetEnabledWeb { get; set; }
    }
}
