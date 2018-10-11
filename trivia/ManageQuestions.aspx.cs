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
            if (!IsPostBack)
            {
                //Update Drop-Down List with Categories                      
                ddlCategory.DataSource = qc.GetCategories().ToList();
                ddlCategory.DataValueField = "CategoryId";
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataBind();

                UpdateScreen();
            }  
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
           

            //Update GridView with Questions
            var queryQuestions =
                tdm.Question
                    .Join(tdm.QuestionCategory, qc => qc.QuestionId, q => q.QuestionId, (qc, q) => 
                    new
                    {
                        qcID = qc.QuestionId,
                        qID = q.QuestionId,
                        qText = qc.QuestionText,
                        qCategory = q.CategoryId
                    })
                    .Where(a => a.qCategory.ToString() == ddlCategory.SelectedValue);
            gvQuestions.DataSource = queryQuestions.ToList();
            gvQuestions.DataBind();
        }

        private void ClearFields()
        {
            txtQuestion.Text = "";
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateScreen();
        }
    }
}