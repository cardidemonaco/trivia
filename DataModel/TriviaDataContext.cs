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
        public DbSet<Question> Question { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswer { get; set; }
        public DbSet<Answer> Answer { get; set; }

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    public class TriviaDataContextInitialization
    : CreateDatabaseIfNotExists<TriviaDataContext>
    {
        protected override void Seed(TriviaDataContext context)
        {
            context.Question.Add(new Question { QuestionText = "What is 2 + 2?" });
            context.Question.Add(new Question { QuestionText = "Who is the Chief Justice of the Michigan Supreme Court?" });
            context.Question.Add(new Question { QuestionText = "Who is the Chief Judge of the Michigan Court of Appeals?" });
            context.Question.Add(new Question { QuestionText = "Where is the Michigan Hall of Justice?" });
            context.Question.Add(new Question { QuestionText = "How many Districts are in the Michigan Court of Appeals?" });
            context.Question.Add(new Question { QuestionText = "How many Judges are on the Michigan Court of Appeals?" });
            context.Question.Add(new Question { QuestionText = "How many Justices are on the Michigan Supreme Court?" });
        }
    }
}