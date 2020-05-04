using CwConverter.ViewModels;

namespace CwConverter.Views
{
    /// <summary>
    /// Interaction logic for InterfaceView.xaml
    /// </summary>
    public partial class InterfaceView
    {
        public InterfaceView()
        {
            InitializeComponent();
            DataContext = new InterfaceViewModel();
        }
    }
}
