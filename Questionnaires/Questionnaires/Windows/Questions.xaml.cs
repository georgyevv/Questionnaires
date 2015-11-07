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
    public partial class Questions : Window
    {
        private readonly Book book;
        private readonly List<Question> questions;
        private int selectedQuestionIndex;

        public Questions(int bookId)
        {
            InitializeComponent();
            using (BookQuestions context = new BookQuestions())
            {
                Book searchedBook = context.Books
                    .Include("Questions")
                    .Include("Questions.Answers")
                    .FirstOrDefault(b => b.Id == bookId);
                this.book = searchedBook;
                this.questions = searchedBook.Questions.ToList();
            }

            this.labelBookName.Content = this.book.Name;
            this.labelQuestionName.Content = this.book.Questions.ToList()[0].Name;
            this.answersList.ItemsSource = this.questions.FirstOrDefault().Answers;
            this.selectedQuestionIndex = 0;
            this.labelCurrentOf.Content = $"Question {selectedQuestionIndex + 1} of {this.questions.Count}";
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            this.selectedQuestionIndex++;
            if (this.selectedQuestionIndex +  1 >= this.questions.Count)
            {
                (sender as Button).IsEnabled = false;
            }
            if (this.selectedQuestionIndex + 1 > 1)
            {
                this.prevButton.IsEnabled = true;
            }
            SetQuestionInformation(sender);
        }
        private void prevButton_Click(object sender, RoutedEventArgs e)
        {
            this.selectedQuestionIndex--;
            if (this.selectedQuestionIndex < 1)
            {
                (sender as Button).IsEnabled = false;
            }
            if (this.selectedQuestionIndex + 1 < this.questions.Count)
            {
                this.nextButton.IsEnabled = true;
            }
            SetQuestionInformation(sender);
        }

        private void SetQuestionInformation(object sender)
        {
            Question nextQuestion = this.questions[this.selectedQuestionIndex];
            this.labelQuestionName.Content = nextQuestion.Name;
            this.answersList.ItemsSource = nextQuestion.Answers;
            this.labelCurrentOf.Content = $"Question {selectedQuestionIndex + 1} of {this.questions.Count}";
        }
    }
}
