using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private Dictionary<string, Stock> portfolio;

        public Investor(string fullName, string emailaddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailaddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;

            portfolio = new Dictionary<string, Stock>();
        }

        public int Count { get { return portfolio.Count; } }

        private string fullName;

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        private string emailAddress;

        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        private decimal moneyToInvest;

        public decimal MoneyToInvest
        {
            get { return moneyToInvest; }
            set { moneyToInvest = value; }
        }

        private string brokerName;

        public string BrokerName
        {
            get { return brokerName; }
            set { brokerName = value; }
        }

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && MoneyToInvest >= stock.PricePerShare)
            {
                MoneyToInvest -= stock.PricePerShare;
                portfolio.Add(stock.CompanyName, stock);
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            if (!portfolio.ContainsKey(companyName))
            {
                return $"{companyName} does not exist.";
            }
            else if (sellPrice < portfolio[companyName].PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }
            else
            {
                portfolio.Remove(companyName);
                MoneyToInvest += sellPrice;
                return $"{companyName} was sold.";
            }
        }

        public Stock FindStock(string companyName)
        {
            if (portfolio.ContainsKey(companyName))
            {
                return portfolio[companyName];
            }
            else
            {
                return null;
            }

        }

        public Stock FindBiggestCompany()
        {
            if (portfolio.Count > 0)
            {
                string companyName = string.Empty;
                return portfolio.Values.OrderByDescending(s => s.MarketCapitalization).First();
                
            }
            else
            {
                return null;
            }
        }

        public string InvestorInformation()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"The investor {fullName} with a broker {brokerName} has stocks:");
            foreach (var item in portfolio)
            {
                result.AppendLine(item.Value.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
