﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Trivia.DataModel;

namespace trivia
{
    public partial class ManageAnswers : System.Web.UI.Page
    {
        private TriviaDataContext tdm = new TriviaDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCategory.DataSource = tdm.Category.ToList();
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataValueField = "CategoryID";
                ddlCategory.DataBind();

                UpdateScreen();
            }
        }

        protected void ddlQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlQuestions.SelectedValue != "0")
            {
                //Get current answers for selected question and bind to GridView
                int questionId = Convert.ToInt32(ddlQuestions.SelectedValue);
                var query = tdm.QuestionAnswer
                               .Where(qa => qa.QuestionId == questionId)
                               .Select(qa => new { qa.Answer.AnswerText, qa.CorrectAnswer });
                gvCurrentAnswers.DataSource = query.ToList();
                gvCurrentAnswers.DataBind();
            }
        }

        protected void btnAnswersAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //Save each Answer 
                if (txtAnswer1.Text != "")
                {
                    //Add Answer text to database...
                    Answer a1 = new Answer() { AnswerText = txtAnswer1.Text };
                    tdm.Answer.Add(a1);

                    QuestionAnswer qa1 = new QuestionAnswer()
                    {
                        QuestionId = Convert.ToInt32(ddlQuestions.SelectedValue),
                        Answer = a1,
                        CorrectAnswer = cbAnswer1.Checked
                    };
                    tdm.QuestionAnswer.Add(qa1);

                    //Add Documentation to file system...
                    //File.Copy(fuAnswer1.FileName, "/Documentation/" + fuAnswer1.FileName);
                    if (fuAnswer1.FileName != "")
                        fuAnswer1.SaveAs(Request.PhysicalApplicationPath + @"\Documentation\" + fuAnswer1.FileName);
                }

                if (txtAnswer2.Text != "")
                {
                    Answer a2 = new Answer() { AnswerText = txtAnswer2.Text };
                    tdm.Answer.Add(a2);

                    QuestionAnswer qa2 = new QuestionAnswer()
                    {
                        QuestionId = Convert.ToInt32(ddlQuestions.SelectedValue),
                        Answer = a2,
                        CorrectAnswer = cbAnswer2.Checked
                    };
                    tdm.QuestionAnswer.Add(qa2);
                }

                if (txtAnswer3.Text != "")
                {
                    Answer a3 = new Answer() { AnswerText = txtAnswer3.Text };
                    tdm.Answer.Add(a3);

                    QuestionAnswer qa3 = new QuestionAnswer()
                    {
                        QuestionId = Convert.ToInt32(ddlQuestions.SelectedValue),
                        Answer = a3,
                        CorrectAnswer = cbAnswer3.Checked
                    };
                    tdm.QuestionAnswer.Add(qa3);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
            finally
            {
                //Save changes to the database
                tdm.SaveChanges();
            }
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Questions = tdm.Question
                .Join(tdm.QuestionCategory, q => q.QuestionId, qc => qc.QuestionId, (q, qc) => new
                {
                    q.QuestionId,
                    q.QuestionText,
                    qc.CategoryId
                })
                .Where(a => a.CategoryId.ToString() == ddlCategory.SelectedValue);

        }

        protected void gvPotentialAnswers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }

        private void UpdateScreen()
        {
            //Update GridView with Questions
            var queryQuestions =
                tdm.Question
                    .Select(q => new { q.QuestionId, q.QuestionText })
                    .OrderBy(q => q.QuestionText);
            ddlQuestions.DataSource = queryQuestions.ToList();
            ddlQuestions.DataValueField = "QuestionId";
            ddlQuestions.DataTextField = "QuestionText";
            ddlQuestions.DataBind();

            //Insert dummy record in drop-down list
            ListItem li = new ListItem() { Value = "0", Text = "-- SELECT A QUESTION --" };
            ddlQuestions.Items.Insert(0, li);

            //Add 3 blank rows to the DataTable (allow "add" button for more)
            DataTable dt = new DataTable();
            dt.Columns.Add("Answer");
            dt.Columns.Add("Files");
            dt.Columns.Add("CorrectAnswer");

            for (int i=0;i<3;i++)
            {
                DataRow dtRow = dt.NewRow();
                dt.Rows.Add(dtRow);
            }

            //Set Answers GridView to edit mode immediately
            gvPotentialAnswers.EditIndex = 0;

            //Bind data
            gvPotentialAnswers.DataSource = dt;
            gvPotentialAnswers.DataBind();
        }

        private void ClearScreen()
        {
            txtAnswer1.Text = "";
            txtAnswer2.Text = "";
            txtAnswer3.Text = "";
            cbAnswer1.Checked = false;
            cbAnswer2.Checked = false;
            cbAnswer3.Checked = false;
        }
    }
}