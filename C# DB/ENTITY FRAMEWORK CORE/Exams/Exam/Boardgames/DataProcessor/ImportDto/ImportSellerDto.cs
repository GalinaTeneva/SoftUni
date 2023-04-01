﻿using Boardgames.Common;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Boardgames.DataProcessor.ImportDto
{
    public class ImportSellerDto
    {
        [Required]
        [MinLength(ValidationConstants.SellerNameMinLength)]
        [MaxLength(ValidationConstants.SellerNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(ValidationConstants.SellerAddressMinLength)]
        [MaxLength(ValidationConstants.SellerAddressMaxLength)]
        public string Address { get; set; } = null!;

        [Required]
        public string Country { get; set; } = null!;

        [Required]
        [RegularExpression(ValidationConstants.SellerWebsiteRegEx)]
        public string Website { get; set; } = null!;

        [JsonProperty("Boardgames")]
        public int[]? BoardgameIds { get; set; } = null!;
    }
}
