using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Trivia.DataModel;

namespace Trivia.BusinessLogic
{
    public class QuizController
    {
        private TriviaDataContext tdm = new TriviaDataContext();
        public IQueryable<Category> GetCategories()
        {
            IQueryable<Category> queryCategories =
                tdm.Category
                    .Select(c => c)
                    .OrderBy(c => c.CategoryName);

            return queryCategories;
        }


    }
}
