using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Trivia.DataModel;

namespace trivia
{
    public partial class _Default : Page
    {
        private TriviaDataModel tdm = new TriviaDataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateScreen();
        }

        protected void btnQuestionAdd_Click(object sender, EventArgs e)
        {
            Question q = new Question() { QuestionText = txtQuestion.Text };
            tdm.Question.Add(q);
            tdm.SaveChanges();
            UpdateScreen();
        }

        private void UpdateScreen()
        {
            gvQuestions.DataSource = (from q in tdm.Question
                                      select q.QuestionText).ToList();
            gvQuestions.DataBind();
        }
    }
}