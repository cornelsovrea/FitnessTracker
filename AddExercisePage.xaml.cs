using FitnessTracker.Models;

namespace FitnessTracker
{
    public partial class AddExercisePage : ContentPage
    {
        public AddExercisePage(Exercise exercise = null)
        {
            InitializeComponent();
            BindingContext = exercise ?? new Exercise
            {
                Date = DateTime.Now
            };
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var exercise = (Exercise)BindingContext;
            await App.Database.SaveExerciseAsync(exercise);
            await Navigation.PopAsync();
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            var exercise = (Exercise)BindingContext;
            await App.Database.DeleteExerciseAsync(exercise);
            await Navigation.PopAsync();
        }
    }
}
