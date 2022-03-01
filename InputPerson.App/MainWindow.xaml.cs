using System.Windows;

namespace InputPerson.App
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Show_OnClick(object sender, RoutedEventArgs e)
        {
            var input = Input_Name.InputText;
            Output.Content = input;
        }
    }
}