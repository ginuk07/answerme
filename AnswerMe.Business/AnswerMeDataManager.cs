using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnswerMe.Common.Models;
using AnswerMe.Data;
using AutoMapper;

namespace AnswerMe.Business
{
    public interface IAnswerMeDataManager
    {
        List<QuestionDto> GetQuestions();
        void AddQuestion(QuestionDto question);
        void UpdateQuestion(int id);
    }

    public class AnswerMeDataManager : IAnswerMeDataManager
    {
        #region Constructors & Dependencies

        private readonly IAnswerMeDataProviderFactory _dataProviderFactory;

        public AnswerMeDataManager() : this(new AnswerMeDataProviderFactory())
        {
        }

        public AnswerMeDataManager(IAnswerMeDataProviderFactory dataProviderFactory)
        {
            _dataProviderFactory = dataProviderFactory;
        }

        #endregion

        public List<QuestionDto> GetQuestions()
        {
            using (var dataContext = _dataProviderFactory.Create())
            {
                AutoMapperInitializer.Initialize();
                var questions = dataContext.GetQuestions();
                return questions.Select(Mapper.Map<Question, QuestionDto>).ToList();
            }
        }
 
        public void AddQuestion(QuestionDto question)
        {
            // TODO AS: Add in error handling.
            using (var dataContext = _dataProviderFactory.Create())
            {
                question.DateUpdated = DateTime.Now;
                var questionForDb = Mapper.Map<QuestionDto, Question>(question);
                dataContext.AddQuestion(questionForDb);
            }
        }

        public QuestionDto GetQuestion(int id)
        {
            using (var dataContext = _dataProviderFactory.Create())
            {
                AutoMapperInitializer.Initialize();
                var question = dataContext.GetQuestion(id);
                return Mapper.Map<Question, QuestionDto>(question);
            }
        }

        public void UpdateQuestion(int id)
        {
            using (var dataContext = _dataProviderFactory.Create())
            {
                dataContext.UpdateQuestion(id);
            }
        }
    }
}
