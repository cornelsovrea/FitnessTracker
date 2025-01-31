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
            await Navigation.PushAsync(new AddExercisePage
            {
                BindingContext = new Exercise()
            }
            );
        }

        private async void OnExerciseSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Exercise selectedExercise)
            {
                await Navigation.PushAsync(new AddExercisePage
                {
                    BindingContext = selectedExercise
                }
                );
            }

            exerciseListView.SelectedItem = null;
        }
    }
}