using System.Windows;

namespace Aurelius
{
    public partial class MainWindow : Window
    {
        private readonly StockDataService _dataService;
        private readonly PortfolioManager _portfolioManager;
        private readonly AIAssistantService _aiService;

        public MainWindow()
        {
            InitializeComponent();

            // Initialize services
            _dataService = new StockDataService();
            _portfolioManager = new PortfolioManager();
            _aiService = new AIAssistantService();

            // Set the main data context
            DataContext = new MainViewModel(_dataService, _portfolioManager, _aiService);
        }
    }
}