using FitnessTracker.Models;

namespace FitnessTracker
{

    public partial class AddWorkoutPage : ContentPage
    {
        public AddWorkoutPage(Workout workout = null)
        {
            InitializeComponent();
            BindingContext = workout ?? new Workout
            {
                Date = DateTime.Now
            };
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var workout = (Workout)BindingContext;

            if (0 != workout.ID)
            {
                workout.ExerciseLogs = await App.Database.GetExerciseLogList(workout.ID);
                List<Exercise> exercises = await App.Database.GetExerciseItemsList(workout.ID);
                for (int i = 0; i < exercises.Count; i++)
                {
                    workout.ExerciseLogs.ElementAt(i).Exercise = exercises.ElementAt(i);
                }

                listView.ItemsSource = workout.ExerciseLogs;
            }
            else
            {
                listView.ItemsSource = null;
            }
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var workout = (Workout)BindingContext;
            await App.Database.SaveWorkoutAsync(workout);
            await Navigation.PopAsync();
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            var workout = (Workout)BindingContext;
            await App.Database.DeleteWorkoutAsync(workout);
            await Navigation.PopAsync();
        }

        async void OnAddExerciseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddExerciseLogPage((Workout)this.BindingContext)
            {
                BindingContext = new ExerciseLog()
            });
        }

        private async void OnExerciseLogSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var workout = (Workout)BindingContext;
            if (e.SelectedItem is ExerciseLog exerciseLog)
            {
                await Navigation.PushAsync(new AddExerciseLogPage(workout)
                {
                    BindingContext = (ExerciseLog)e.SelectedItem
                });
            }

            listView.SelectedItem = null;
        }

    }
}