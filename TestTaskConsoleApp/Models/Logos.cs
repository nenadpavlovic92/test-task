using Newtonsoft.Json;

namespace TestTaskConsoleApp.Models
{
    /// <summary>
    /// Represents a JSON model of book logos.
    /// </summary>
    public class Logos
    {
        /// <summary>
        /// Get or sets the promo logo of book.
        /// </summary>
        [JsonProperty("promo")]
        public string? Promo { get; set; }

        /// <summary>
        /// Get or sets the primary logo of book.
        /// </summary>
        [JsonProperty("primary")]
        public string? Primary { get; set; }

        /// <summary>
        /// Get or sets the thumbnail logo of book.
        /// </summary>
        [JsonProperty("thumbnail")]
        public string? Thumbnail { get; set; }

        /// <summary>
        /// Get or sets the brand dark logo of book.
        /// </summary>
        [JsonProperty("brand_dark")]
        public string? BrandDark { get; set; }

        /// <summary>
        /// Get or sets the brand light logo of book.
        /// </summary>
        [JsonProperty("brand_light")]
        public string? BrandLight { get; set; }

        /// <summary>
        /// Get or sets the transparent logo of book.
        /// </summary>
        [JsonProperty("transparent")]
        public string? Transparent { get; set; }

        /// <summary>
        /// Get or sets the betslip carousel logo of book.
        /// </summary>
        [JsonProperty("betslip_carousel")]
        public string? BetSlipCarousel { get; set; }
    }
}
