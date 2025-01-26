using FitnessTracker.Data;

namespace FitnessTracker
{
    public partial class App : Application
    {
        public static ExerciseDatabase Database { get; private set; }

        public App(ExerciseDatabase database)
        {
            InitializeComponent();
            Database = database;
            MainPage = new NavigationPage(new MainPage());
        }
    }
}
