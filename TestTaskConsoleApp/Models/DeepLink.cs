using Newtonsoft.Json;

namespace TestTaskConsoleApp.Models
{
    /// <summary>
    /// Represents a JSON model of book deep link.
    /// </summary>
    public class DeepLink
    {
        /// <summary>
        /// Get or sets if book has multiple deep links.
        /// </summary>
        [JsonProperty("has_multi")]
        public bool? HasMulti { get; set; }

        /// <summary>
        /// Get or sets if book has deeplink supported.
        /// </summary>
        [JsonProperty("is_supported")]
        public bool? IsSupported { get; set; }
    }
}
