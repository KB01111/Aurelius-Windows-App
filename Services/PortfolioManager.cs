using System;
using System.Collections.Generic;
using System.Linq;

namespace Aurelius
{
    public class PortfolioManager
    {
        private List<Holding> _holdings;
        private List<Stock> _watchlist;

        public PortfolioManager()
        {
            // Initialize with sample data
            _holdings = new List<Holding>();
            _watchlist = new List<Stock>();
            LoadSampleData();
        }

        public List<Holding> GetHoldings()
        {
            return _holdings;
        }

        public List<Stock> GetWatchlist()
        {
            return _watchlist;
        }

        public void AddHolding(Holding holding)
        {
            _holdings.Add(holding);
        }

        public void RemoveHolding(string id)
        {
            _holdings.RemoveAll(h => h.Id == id);
        }

        public void AddToWatchlist(Stock stock)
        {
            if (!_watchlist.Any(s => s.Symbol == stock.Symbol))
            {
                _watchlist.Add(stock);
            }
        }

        public void RemoveFromWatchlist(string symbol)
        {
            _watchlist.RemoveAll(s => s.Symbol == symbol);
        }

        public double CalculatePortfolioValue()
        {
            return _holdings.Sum(h => h.Shares * h.Stock.Price);
        }

        public double CalculateDailyChange()
        {
            return _holdings.Sum(h => h.Shares * h.Stock.Change);
        }

        public double CalculateTotalGain()
        {
            return _holdings.Sum(h => h.Shares * (h.Stock.Price - h.PurchasePrice));
        }

        private void LoadSampleData()
        {
            // Sample holdings
            _holdings.Add(new Holding
            {
                Id = "1",
                Stock = new Stock
                {
                    Symbol = "AAPL",
                    Name = "Apple Inc.",
                    Price = 185.92,
                    Change = 2.30,
                    PercentChange = 1.25
                },
                Shares = 10,
                PurchasePrice = 175.50,
                PurchaseDate = DateTime.Now.AddDays(-30)
            });

            _holdings.Add(new Holding
            {
                Id = "2",
                Stock = new Stock
                {
                    Symbol = "MSFT",
                    Name = "Microsoft Corporation",
                    Price = 337.50,
                    Change = -1.63,
                    PercentChange = -0.48
                },
                Shares = 5,
                PurchasePrice = 320.25,
                PurchaseDate = DateTime.Now.AddDays(-60)
            });

            _holdings.Add(new Holding
            {
                Id = "3",
                Stock = new Stock
                {
                    Symbol = "NVDA",
                    Name = "NVIDIA Corporation",
                    Price = 476.35,
                    Change = 19.11,
                    PercentChange = 4.18
                },
                Shares = 8,
                PurchasePrice = 400.10,
                PurchaseDate = DateTime.Now.AddDays(-45)
            });

            // Sample watchlist
            _watchlist.Add(new Stock
            {
                Symbol = "AAPL",
                Name = "Apple Inc.",
                Price = 185.92,
                Change = 2.30,
                PercentChange = 1.25
            });

            _watchlist.Add(new Stock
            {
                Symbol = "MSFT",
                Name = "Microsoft Corporation",
                Price = 337.50,
                Change = -1.63,
                PercentChange = -0.48
            });

            _watchlist.Add(new Stock
            {
                Symbol = "GOOGL",
                Name = "Alphabet Inc.",
                Price = 142.25,
                Change = 1.06,
                PercentChange = 0.75
            });

            _watchlist.Add(new Stock
            {
                Symbol = "AMZN",
                Name = "Amazon.com, Inc.",
                Price = 183.05,
                Change = 3.78,
                PercentChange = 2.10
            });
        }
    }
}