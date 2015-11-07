namespace Questionnaires.Models
{
    using System.Collections.Generic;

    public class Book
    {
        private ICollection<Question> questions;

        public Book()
        {
            this.questions = new HashSet<Question>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Question> Questions
        {
            get { return this.questions; }
            set { this.questions = value; }
        }
    }
}