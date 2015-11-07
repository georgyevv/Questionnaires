namespace Questionnaires.Models
{
    using System.Collections.Generic;

    public class Question
    {
        private ICollection<Answer> answers;

        public Question()
        {
            this.answers = new HashSet<Answer>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Answer> Answers
        {
            get { return this.answers; }
            set { this.answers = value; }
        }
    }
}
