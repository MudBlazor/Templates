using System.Windows;

namespace DefaultBlazor.Desktop.Wpf {

    /// <summary> Interaction logic for MainWindow.xaml. </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Resources.Add("services", Program.ServicesProvider);
            InitializeComponent();
        }
    }
}
