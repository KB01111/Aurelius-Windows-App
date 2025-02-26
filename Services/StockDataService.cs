using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aurelius
{
    public class StockDataService
    {
        // In a real application, this would implement API calls to fetch data
        public StockDataService()
        {
            // Initialize API clients, set up caching, etc.
        }

        public async Task<Stock> GetStockQuote(string symbol)
        {
            // Simulate network delay
            await Task.Delay(300);

            // Return mock data
            return new Stock
            {
                Symbol = symbol,
                Name = GetCompanyName(symbol),
                Price = GetRandomPrice(symbol),
                Change = GetRandomChange(),
                PercentChange = GetRandomPercentChange(),
                Volume = GetRandomVolume(),
                MarketCap = GetRandomMarketCap()
            };
        }

        public async Task<List<Stock>> SearchStocks(string query)
        {
            // Simulate network delay
            await Task.Delay(500);

            // Return mock search results
            var results = new List<Stock>();
            var symbols = new[] { "AAPL", "MSFT", "GOOGL", "AMZN", "META" };

            foreach (var symbol in symbols)
            {
                if (query.Length > 0 && (symbol.Contains(query.ToUpper()) || GetCompanyName(symbol).ToUpper().Contains(query.ToUpper())))
                {
                    results.Add(new Stock
                    {
                        Symbol = symbol,
                        Name = GetCompanyName(symbol),
                        Price = GetRandomPrice(symbol),
                        Change = GetRandomChange(),
                        PercentChange = GetRandomPercentChange(),
                        Volume = GetRandomVolume(),
                        MarketCap = GetRandomMarketCap()
                    });
                }
            }

            return results;
        }

        public async Task<List<NewsItem>> GetNewsForSymbol(string symbol)
        {
            // Simulate network delay
            await Task.Delay(700);

            // Return mock news data
            var news = new List<NewsItem>();
            var titles = new[]
            {
                $"{GetCompanyName(symbol)} Reports Better-Than-Expected Earnings",
                $"Analysts Upgrade {symbol} Following Product Launch",
                $"{symbol} Announces Expansion into International Markets",
                $"Industry Challenges May Impact {GetCompanyName(symbol)}'s Growth Forecast",
                $"{GetCompanyName(symbol)} CEO Discusses Future Strategy in Interview"
            };

            var sources = new[] { "Financial Times", "Wall Street Journal", "Bloomberg", "Reuters", "CNBC" };

            for (int i = 0; i < 5; i++)
            {
                news.Add(new NewsItem
                {
                    Id = i.ToString(),
                    Title = titles[i],
                    Source = sources[i],
                    Summary = $"This is a summary of the news article about {symbol}...",
                    Url = $"https://example.com/news/{symbol}/{i}",
                    PublishedAt = DateTime.Now.AddHours(-i * 6),
                    SentimentScore = GetRandomSentiment()
                });
            }

            return news;
        }

        private string GetCompanyName(string symbol)
        {
            var companies = new Dictionary<string, string>
            {
                { "AAPL", "Apple Inc." },
                { "MSFT", "Microsoft Corporation" },
                { "GOOGL", "Alphabet Inc." },
                { "AMZN", "Amazon.com, Inc." },
                { "META", "Meta Platforms, Inc." },
                { "TSLA", "Tesla, Inc." },
                { "NVDA", "NVIDIA Corporation" },
                { "JPM", "JPMorgan Chase & Co." },
                { "V", "Visa Inc." },
                { "WMT", "Walmart Inc." }
            };

            return companies.ContainsKey(symbol) ? companies[symbol] : $"{symbol} Corp";
        }

        private double GetRandomPrice(string symbol)
        {
            var random = new Random();
            var basePrice = symbol.Length * 50 + random.NextDouble() * 100;
            return Math.Round(basePrice, 2);
        }

        private double GetRandomChange()
        {
            var random = new Random();
            return Math.Round((random.NextDouble() * 10) - 5, 2);
        }

        private double GetRandomPercentChange()
        {
            var random = new Random();
            return Math.Round((random.NextDouble() * 5) - 2.5, 2);
        }

        private long GetRandomVolume()
        {
            var random = new Random();
            return random.Next(1000000, 50000000);
        }

        private double GetRandomMarketCap()
        {
            var random = new Random();
            return random.Next(10, 2000) * 1000000000.0;
        }

        private double GetRandomSentiment()
        {
            var random = new Random();
            return Math.Round(random.NextDouble(), 2);
        }
    }
}