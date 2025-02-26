using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Aurelius
{
    // Data Models
    public class Stock
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Change { get; set; }
        public double PercentChange { get; set; }
        public long Volume { get; set; }
        public double MarketCap { get; set; }
    }

    public class Holding
    {
        public string Id { get; set; }
        public Stock Stock { get; set; }
        public int Shares { get; set; }
        public double PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }

        public double CurrentValue => Shares * Stock.Price;
        public double CostBasis => Shares * PurchasePrice;
        public double GainLoss => CurrentValue - CostBasis;
        public double GainLossPercent => (GainLoss / CostBasis) * 100;
    }

    public class NewsItem
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Source { get; set; }
        public string Summary { get; set; }
        public string Url { get; set; }
        public DateTime PublishedAt { get; set; }
        public double SentimentScore { get; set; }
    }

    public class ChatMessage
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public bool IsUser { get; set; }
        public DateTime Timestamp { get; set; }
    }

    // UI Data Models
    public class PortfolioHolding : INotifyPropertyChanged
    {
        private string _symbol;
        public string Symbol
        {
            get => _symbol;
            set
            {
                if (_symbol != value)
                {
                    _symbol = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _company;
        public string Company
        {
            get => _company;
            set
            {
                if (_company != value)
                {
                    _company = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _shares;
        public int Shares
        {
            get => _shares;
            set
            {
                if (_shares != value)
                {
                    _shares = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _averageCost;
        public string AverageCost
        {
            get => _averageCost;
            set
            {
                if (_averageCost != value)
                {
                    _averageCost = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _currentPrice;
        public string CurrentPrice
        {
            get => _currentPrice;
            set
            {
                if (_currentPrice != value)
                {
                    _currentPrice = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _marketValue;
        public string MarketValue
        {
            get => _marketValue;
            set
            {
                if (_marketValue != value)
                {
                    _marketValue = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _gainLoss;
        public string GainLoss
        {
            get => _gainLoss;
            set
            {
                if (_gainLoss != value)
                {
                    _gainLoss = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _gainLossPercent;
        public string GainLossPercent
        {
            get => _gainLossPercent;
            set
            {
                if (_gainLossPercent != value)
                {
                    _gainLossPercent = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ApiEndpoint
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Method { get; set; }
    }

    public class ChatTemplate
    {
        public string Name { get; set; }
        public string Prompt { get; set; }
    }

    public class CustomAlert
    {
        public string Symbol { get; set; }
        public string Type { get; set; }
        public string Condition { get; set; }
        public string Value { get; set; }
        public bool IsActive { get; set; }
    }
}