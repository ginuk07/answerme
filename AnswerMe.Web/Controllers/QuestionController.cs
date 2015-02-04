using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using AnswerMe.Business;
using AnswerMe.Common.Models;

namespace AnswerMe.Web.Controllers
{
    public class QuestionController : Controller
    {
        #region constructors and dependencies

        private readonly IAnswerMeDataManager _dataManager;

        public QuestionController() : this(new AnswerMeDataManager())
        {
        }

        public QuestionController(IAnswerMeDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        #endregion

        public ActionResult Questions()
        {
            var model = _UnansweredQuestions();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(AnswerMe.Common.Models.QuestionDto model)
        {
            _dataManager.AddQuestion(model);
            return RedirectToAction("Questions");
        }

        [HttpGet]
        public ActionResult Create()
        {
            var questionText = Request.QueryString["Body"];

            if (!String.IsNullOrEmpty(questionText))
            {
                var question = new QuestionDto {QuestionText = questionText};
                _dataManager.AddQuestion(question);
            }
            
            return RedirectToAction("Questions");
        }

        [OutputCache(NoStore = true, Location = OutputCacheLocation.Client, Duration = 3)] // every 3 sec
        public ActionResult GetContributor()
        {
            IEnumerable<QuestionDto> list = _UnansweredQuestions();
            return PartialView("_AllQuestions", list);
        }

        public List<QuestionDto> _Questions()
        {
            return _dataManager.GetQuestions();
        }

        public List<QuestionDto> _UnansweredQuestions()
        {
            var allQuestions = _dataManager.GetQuestions();
            return allQuestions.FindAll(x => x.Answered == false);
        }

        public ActionResult UpdateQuestion(int id)
        {
            _dataManager.UpdateQuestion(id);
            return RedirectToAction("Questions");
        }


    }
}
