using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer.DTOs.Export
{
    public class ExportTotalSalesByCustomerDto
    {
        [JsonProperty("fullName")]
        public string FullName { get; set; } = null!;

        [JsonProperty("boughtCars")]
        public int BoughtCars { get; set; }

        [JsonProperty("spentMoney")]
        public decimal SpentMoney => GetSaleValue();

        [JsonIgnore]
        public bool IsYoungDriver { get; set; }

        [JsonIgnore]
        public ICollection<Sale> Sales { get; set; } = null!;

        private decimal GetSaleValue()
        {
            decimal youngDriversDiscount = 0.05m;
            decimal value = 0;

            foreach (Sale sale in Sales)
            {
                value = sale.Car.PartsCars.Sum(x => x.Part.Price);

                if (sale.Customer.IsYoungDriver)
                {
                    value -= value * youngDriversDiscount;
                }
            }

            return value;
        }
    }
}
