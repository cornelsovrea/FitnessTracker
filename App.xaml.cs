using FitnessTracker.Data;

namespace FitnessTracker
{
    public partial class App : Application
    {
        static ExerciseDatabase database;
        public static ExerciseDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                   ExerciseDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                   LocalApplicationData), "ExerciseDatabase.db3"));
                }
                return database;
            }
        }

        public App(ExerciseDatabase database)
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}
