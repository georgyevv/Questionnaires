using System.Windows;

namespace Questionnaires.Windows
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            BookList bookList = new BookList();
            bookList.Show();
            this.Close();
        }
    }
}
