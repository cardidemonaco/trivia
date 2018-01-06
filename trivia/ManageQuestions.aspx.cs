using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

using Trivia.BusinessLogic;
using Trivia.DataModel;

namespace trivia
{
    public partial class _Default : Page
    {
        private TriviaDataContext tdm = new TriviaDataContext();
        private QuizController qc = new QuizController();
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

        protected void btnCategoryAdd_Click(object sender, EventArgs e)
        {
            Category c = new Category() { CategoryName = txtCategory.Text };
            tdm.Category.Add(c);
            tdm.SaveChanges();
            UpdateScreen();
        }

        private void UpdateScreen()
        {
            //Update Drop-Down List with Categories                      
            ddlCategory.DataSource = qc.GetCategories().ToList();
            ddlCategory.DataValueField = "CategoryId";
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataBind();


            //Update GridView with Questions
            var queryQuestions =
                tdm.Question
                    .Select(q => new { q.QuestionText });
            gvQuestions.DataSource = queryQuestions.ToList();
            gvQuestions.DataBind();
        }

        private void ClearFields()
        {
            txtQuestion.Text = "";
        }


    }
}