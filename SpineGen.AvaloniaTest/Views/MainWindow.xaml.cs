using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using SpineGen.AvaloniaTest.ViewModels;

namespace SpineGen.AvaloniaTest.Views
{
    public class MainWindow : Window
    {
        public new MainWindowViewModel DataContext { get => base.DataContext as MainWindowViewModel; set => base.DataContext = value; }
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void OnTemplateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox)
            {

            }
        }
    }
}
