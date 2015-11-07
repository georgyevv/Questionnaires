using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Questionnaires.Models;
using Questionnaries.Data;

namespace Questionnaires.Windows
{
    public partial class BookList : Window
    {
        public BookList()
        {
            InitializeComponent();

            using (BookQuestions context = new BookQuestions())
            {
                IEnumerable<Book> books = context.Books.ToList();
                this.ListBoxBooks.ItemsSource = books;
            }
        }
        
        private void ListBoxBooks_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if (listBox != null)
            {
                Book selectedBook = e.AddedItems[0] as Book;
                Questions questionWindow = new Questions(selectedBook.Id);
                questionWindow.Show();
                this.Close();
            }
        }
    }
}