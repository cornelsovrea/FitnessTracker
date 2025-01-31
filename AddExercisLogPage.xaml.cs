using FitnessTracker.Models;

namespace FitnessTracker
{
    public partial class AddExerciseLogPage : ContentPage
    {
        Workout workout;
        public AddExerciseLogPage(Workout selectedWorkout)
        {
            InitializeComponent();
            workout = selectedWorkout;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var items = await App.Database.GetExercisesAsync();
            ExercisePicker.ItemsSource = (System.Collections.IList)items;
            ExercisePicker.ItemDisplayBinding = new Binding("Name");

            var exerciseLog = (ExerciseLog)BindingContext;
            if (exerciseLog.ExerciseID != null)
            {
                ExercisePicker.SelectedItem = items.FirstOrDefault(item => item.ID == exerciseLog.ExerciseID);
            }
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var exerciseLog = (ExerciseLog)BindingContext;
            Exercise selectedExercise = (ExercisePicker.SelectedItem as Exercise);
            exerciseLog.ExerciseID = selectedExercise.ID;
            exerciseLog.WorkoutID = workout.ID;
            await App.Database.SaveExerciseLogAsync(exerciseLog);
            await Navigation.PopAsync();
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            var exerciseLog = (ExerciseLog)BindingContext;
            await App.Database.DeleteExerciseLogAsync(exerciseLog);
            await Navigation.PopAsync();
        }
    }
}