using CwConverter.ViewModels;
using System.Windows.Controls;

namespace CwConverter.Views
{
    /// <summary>
    /// Interaction logic for InterfaceView.xaml
    /// </summary>
    public partial class InterfaceView : UserControl
    {
        public InterfaceView()
        {
            InitializeComponent();
            DataContext = new InterfaceViewModel();
        }
    }
}
