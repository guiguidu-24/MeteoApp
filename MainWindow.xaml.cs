using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MeteoApp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MeteoApplicationViewModel();

            RefreshBtn.Click += (DataContext as MeteoApplicationViewModel).OnRequest;
        }
    }
}
