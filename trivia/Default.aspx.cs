using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Trivia.BusinessLogic;

namespace trivia
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private QuizController qc = new QuizController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvQuizCategories.DataSource = qc.GetCategories().ToList();
                gvQuizCategories.DataBind();
            }


        }
    }
}