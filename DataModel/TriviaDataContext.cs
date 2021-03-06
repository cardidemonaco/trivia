namespace Trivia.DataModel
{
    using System.Data.Entity;

    public class TriviaDataContext : DbContext
    {
        // Your context has been configured to use a 'triviaDataModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DataModel.triviaDataModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'triviaDataModel' 
        // connection string in the application configuration file.
        public TriviaDataContext()
        {
            Database.SetInitializer<TriviaDataContext>(new TriviaDataContextInitialization());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.
        public DbSet<Category> Category { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<QuestionCategory> QuestionCategory { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswer { get; set; }
        public DbSet<Answer> Answer { get; set; }

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    public class TriviaDataContextInitialization
    : CreateDatabaseIfNotExists<TriviaDataContext>
    {
        protected override void Seed(TriviaDataContext context)
        {
            //Category table
            context.Category.Add(new Category { CategoryName = "Miscellaneous" }); //1
            context.Category.Add(new Category { CategoryName = "Government" }); //2
            context.Category.Add(new Category { CategoryName = "Technology" }); //3

            //Question table
            context.Question.Add(new Question { QuestionText = "What is 2 + 2?" });
            context.Question.Add(new Question { QuestionText = "Who is the Chief Justice of the Michigan Supreme Court?" });
            context.Question.Add(new Question { QuestionText = "Who is the Chief Judge of the Michigan Court of Appeals?" });
            context.Question.Add(new Question { QuestionText = "Where is the Michigan Hall of Justice?" });
            context.Question.Add(new Question { QuestionText = "How many Districts are in the Michigan Court of Appeals?" });
            context.Question.Add(new Question { QuestionText = "How many Judges are on the Michigan Court of Appeals?" });
            context.Question.Add(new Question { QuestionText = "How many Justices are on the Michigan Supreme Court?" });

            //Question Category table
            context.QuestionCategory.Add(new QuestionCategory { CategoryId = 1, QuestionId = 1 });
            context.QuestionCategory.Add(new QuestionCategory { CategoryId = 2, QuestionId = 2 });
            context.QuestionCategory.Add(new QuestionCategory { CategoryId = 2, QuestionId = 3 });
            context.QuestionCategory.Add(new QuestionCategory { CategoryId = 2, QuestionId = 4 });
            context.QuestionCategory.Add(new QuestionCategory { CategoryId = 2, QuestionId = 5 });
            context.QuestionCategory.Add(new QuestionCategory { CategoryId = 2, QuestionId = 6 });
            context.QuestionCategory.Add(new QuestionCategory { CategoryId = 2, QuestionId = 7 });

            //Answer table
            context.Answer.Add(new Answer { AnswerText = "4" }); //1
            context.Answer.Add(new Answer { AnswerText = "3" }); //2
            context.Answer.Add(new Answer { AnswerText = "5" }); //3
            context.Answer.Add(new Answer { AnswerText = "Justice Stephen Markman" }); //4

            //Question Answer table
            context.QuestionAnswer.Add(new QuestionAnswer { QuestionId = 1, AnswerId = 1, CorrectAnswer = true });
            context.QuestionAnswer.Add(new QuestionAnswer { QuestionId = 1, AnswerId = 2, CorrectAnswer = false });
            context.QuestionAnswer.Add(new QuestionAnswer { QuestionId = 1, AnswerId = 3, CorrectAnswer = false });
            context.QuestionAnswer.Add(new QuestionAnswer { QuestionId = 2, AnswerId = 4, CorrectAnswer = true });
        }
    }
}