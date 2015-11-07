namespace Questionnaries.Data
{
    using Questionnaires.Models;
    using System.Data.Entity;

    public class BookQuestions : DbContext
    {
        public BookQuestions()
            : base("name=BookQuestions")
        {
        }

        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Question> Questions { get; set; }

        public virtual DbSet<Answer> Answers { get; set; }
    }
}