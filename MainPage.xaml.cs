using FitnessTracker.Models;

namespace FitnessTracker
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            exerciseListView.ItemsSource = await App.Database.GetExercisesAsync();
        }

        private async void OnAddExerciseClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddExercisePage());
        }

        private async void OnExerciseSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Exercise selectedExercise)
            {
                await Navigation.PushAsync(new AddExercisePage(selectedExercise));
            }

            exerciseListView.SelectedItem = null;
        }
    }
}
