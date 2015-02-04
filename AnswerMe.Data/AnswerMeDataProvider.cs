using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AnswerMe.Data
{
    public interface IAnswerMeDataProvider : IDisposable
    {
        IEnumerable<Question> GetQuestions();
        Question GetQuestion(int id);
        void UpdateQuestion(int id);
        void AddQuestion(Question question);
        void Save();
    }

    public class AnswerMeDataProvider : IAnswerMeDataProvider
    {
        #region Constructors & Dependencies

        private readonly AnswerMeEntities _context;

        public AnswerMeDataProvider()
        {
            _context = new AnswerMeEntities();
        }

        #endregion

        public IEnumerable<Question> GetQuestions()
        {
            return (from q in _context.Questions
                    orderby q.DateUpdated descending
                    select q);
        }

        public Question GetQuestion(int id)
        {
            return _context.Questions.SingleOrDefault(x => x.ID == id);
        }

        public void UpdateQuestion(int id)
        {
            var q = _context.Questions.SingleOrDefault(x => x.ID == id);
            q.Answered = true;
            _context.SaveChanges();
        }

        public void AddQuestion(Question question)
        {
            _context.Questions.Add(question);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        #region IDisposable

        public void Dispose()
        {
            _context.Dispose();
        }

        #endregion
    }
}
