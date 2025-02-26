using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Aurelius
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly StockDataService _dataService;
        private readonly PortfolioManager _portfolioManager;
        private readonly AIAssistantService _aiService;

        public MainViewModel(StockDataService dataService, PortfolioManager portfolioManager, AIAssistantService aiService)
        {
            _dataService = dataService;
            _portfolioManager = portfolioManager;
            _aiService = aiService;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}