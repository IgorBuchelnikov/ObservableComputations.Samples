using MahApps.Metro.Controls;
using ObservableComputations.Samples.Infrastructure;

namespace ObservableComputations.Samples
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new SelectableItemCollection();
        }
    }
}
