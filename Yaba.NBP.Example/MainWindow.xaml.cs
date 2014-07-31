using System.Collections.Generic;
using System.Windows;
using NetDevelopersPoland.Yaba.NBP;

namespace Yaba.NBP.Example
{
    public partial class MainWindow : Window
    {
        private NBPApi nbpApi;

        public MainWindow()
        {
            InitializeComponent();
            nbpApi = new NBPApi();
        }

        private void Button_GetActualExchangeRates_Click(object sender, RoutedEventArgs e)
        {
            var list = new List<ExchangeRate>()
                           {
                             nbpApi.GetActualExchangeRate(Currency.EUR),
                             nbpApi.GetActualExchangeRate(Currency.USD),
                             nbpApi.GetActualExchangeRate(Currency.NOK),
                             nbpApi.GetActualExchangeRate(Currency.JPY),
                             nbpApi.GetActualExchangeRate(Currency.GBP)
                           };

            grid.ItemsSource = list;
        }

        private void Button_GetActualBuySellRates_Click(object sender, RoutedEventArgs e)
        {
            var list = new List<BuySellRate>()
                           {
                             nbpApi.GetActualBuySellRate(Currency.EUR),
                             nbpApi.GetActualBuySellRate(Currency.USD),
                             nbpApi.GetActualBuySellRate(Currency.NOK),
                             nbpApi.GetActualBuySellRate(Currency.JPY),
                             nbpApi.GetActualBuySellRate(Currency.GBP)
                           };

            grid.ItemsSource = list;
        }

        private void Button_GetActualBaseRates_Click(object sender, RoutedEventArgs e)
        {
            var list = new List<BaseRate>()
                           {
                             nbpApi.GetActualBaseRate(Rate.Deposit),
                             nbpApi.GetActualBaseRate(Rate.Lombard),
                             nbpApi.GetActualBaseRate(Rate.Reference),
                             nbpApi.GetActualBaseRate(Rate.Rediscount)
                           };

            grid.ItemsSource = list;
        }
    }
}
