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
        protected void Page_Load(object sender, EventArgs e)
        {
            TriviaDataModel tdm = new TriviaDataModel();
            gvQuestions.DataSource = (from q in tdm.Question
                                      select q.QuestionText).ToList();
            gvQuestions.DataBind();
        }
    }
}