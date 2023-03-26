﻿using Newtonsoft.Json;

namespace CarDealer.DTOs.Export
{
    public class ExportTotalSalesByCustomerDto
    {
        [JsonProperty("fullName")]
        public string FullName { get; set; } = null!;

        [JsonProperty("boughtCars")]
        public int BoughtCars { get; set; }

        [JsonProperty("spentMoney")]
        public decimal SpentMoney { get; set; }
    }
}
